

namespace Repository.Repository
{
    using global::Repository.Context;
    using global::Repository.Interface;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollaboratorRepository: ICollaboratorRepository
    {
        public readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                string message = string.Empty;
                var emailExists = this.userContext.Users.Where(x => x.EmailId == collaborator.ColEmail).SingleOrDefault();
                if (emailExists != null)
                {
                    var owner = (from user in userContext.Users
                                 join notes in userContext.Notes
                                 on user.UserId equals notes.UserId
                                 where notes.NotesId == collaborator.NotesId && user.EmailId == collaborator.ColEmail
                                 select new { userId = user.UserId }).SingleOrDefault();
                    if (owner == null)
                    {
                        var colExists = this.userContext.Collaborators.Where(x => x.ColEmail == collaborator.ColEmail && x.NotesId == collaborator.NotesId).SingleOrDefault();
                        if (colExists == null)
                        {
                            this.userContext.Add(collaborator);
                            this.userContext.SaveChanges();
                            message = "Collaborator Added!";
                        }
                        else
                        {
                            message = "This email already exists";
                        }
                    }
                    else
                    {
                        message = "This email already exists";
                    }
                }
                else
                {
                    message = "Invalid Email";
                }
                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RemoveCollaborator(int colId)
        {
            try
            {
                var colExists = this.userContext.Collaborators.Where(x => x.ColId == colId).SingleOrDefault();
                if (colExists != null) {
                    this.userContext.Collaborators.Remove(colExists);
                    this.userContext.SaveChanges();
                    return "Removed Collaborator";
                }
                return "Cant Remove Collaborator";
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetCollaborator(int noteId)
        {
            try
            {
                var collaborators = this.userContext.Collaborators.Where(x=>x.NotesId == noteId).Select(x=>x.ColEmail).ToList();
                if (collaborators.Count>0)
                {
                    return collaborators;
                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
