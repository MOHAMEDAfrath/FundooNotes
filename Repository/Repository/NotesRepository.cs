using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class NotesRepository:INotesRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        public NotesRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                if (notesModel != null)
                {
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note Added Successfully !";
                }
                else
                {
                    return "Notes Not Added SuccessFully !";
                }
            
            }catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateTitleOrNote(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.UserId == notesModel.UserId).FirstOrDefault();
                if (exists != null)
                {
                    if (notesModel.Title == null)
                    {
                        exists.Notes = notesModel.Notes;
                    }
                    else
                    {
                        exists.Title = notesModel.Title;
                    }
                    if (notesModel != null)
                    {
                        this.UserContext.Notes.Update(exists);
                        this.UserContext.SaveChanges();
                        return "Note Updated Successfully !";
                    }
                    else
                    {
                        return "Notes Not Updated SuccessFully !";
                    }
                }
                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateColor(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.UserId == notesModel.UserId).FirstOrDefault();
                if (exists != null)
                {
                    if (notesModel.Color != null)
                    {
                        exists.Color=notesModel.Color;
                        this.UserContext.Notes.Update(exists);
                        this.UserContext.SaveChanges();
                        return "Color Added Successfully !";
                    }
                    else
                    {
                        return "Color not Added Successfully !";
                    }
                }
                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateArchive(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.UserId == notesModel.UserId).FirstOrDefault();
                if (exists != null)
                {
                    if (exists.Is_Archive == true)
                    {
                        exists.Is_Archive = false;
                    }
                    else
                    {
                        exists.Is_Archive = true;
                    }
                        this.UserContext.Notes.Update(exists);
                        this.UserContext.SaveChanges();
                    if (exists.Is_Archive == true)
                    {
                        return "Archived Successfully !";
                    }
                    else
                    {

                        return "Removed from Archive";
                    }
                  
                }
                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddPin(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.UserId == notesModel.UserId).FirstOrDefault();
                if (exists != null)
                {
                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                    }
                    else
                    {
                        exists.Is_Pin = true;
                    }
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    if (exists.Is_Pin == true)
                    {
                        return "Pinned Successfully !";
                    }
                    else
                    {

                        return "Removed from Pin";
                    }

                }
                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteAddToTrash(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.UserId == notesModel.UserId && x.Is_Trash==false).FirstOrDefault();
                if (exists != null)
                {
                    exists.Is_Trash = true;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    return "Added to trash !";

                }
                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<NotesModel> GetNotes(int UserId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x =>x.UserId == UserId && x.Is_Trash == false).ToList();
                if(exists.Count > 0)
                {
                    return exists;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
