// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    ///  class CollaboratorRepository
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// UserContext UserContext
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class
        /// </summary>
        /// <param name="userContext">(UserContext userContext</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        /// <summary>
        /// Adds collaborator
        /// </summary>
        /// <param name="collaborator">CollaboratorModel collaborator</param>
        /// <returns>returns string after adding collaborator</returns>
        public string AddCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                string message = string.Empty;
                var emailExists = this.UserContext.Users.Where(x => x.EmailId == collaborator.ColEmail).SingleOrDefault();
                if (emailExists != null)
                {
                    var owner = (from user in this.UserContext.Users
                                 join notes in this.UserContext.Notes
                                 on user.UserId equals notes.UserId
                                 where notes.NotesId == collaborator.NotesId && user.EmailId == collaborator.ColEmail
                                 select new { userId = user.UserId }).SingleOrDefault();
                    if (owner == null)
                    {
                        var colExists = this.UserContext.Collaborators.Where(x => x.ColEmail == collaborator.ColEmail && x.NotesId == collaborator.NotesId).SingleOrDefault();
                        if (colExists == null)
                        {
                            this.UserContext.Add(collaborator);
                            this.UserContext.SaveChanges();
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

        /// <summary>
        /// Delete collaborator
        /// </summary>
        /// <param name="colId">integer colId</param>
        /// <returns>returns string after deleting collaborator</returns>
        public string RemoveCollaborator(int colId)
        {
            try
            {
                var colExists = this.UserContext.Collaborators.Where(x => x.ColId == colId).SingleOrDefault();
                if (colExists != null) 
                {
                    this.UserContext.Collaborators.Remove(colExists);
                    this.UserContext.SaveChanges();
                    return "Removed Collaborator";
                }

                return "Cant Remove Collaborator";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get collaborator
        /// </summary>
        /// <param name="noteId">integer noteId</param>
        /// <returns>returns string after get collaborator</returns>
        public List<string> GetCollaborator(int noteId)
        {
            try
            {
                var collaborators = this.UserContext.Collaborators.Where(x => x.NotesId == noteId).Select(x => x.ColEmail).ToList();
                if (collaborators.Count > 0)
                {
                    return collaborators;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
