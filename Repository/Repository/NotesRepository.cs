// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
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
    /// class NotesRepository
    /// </summary>
    public class NotesRepository : INotesRepository
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

        /// <summary>
        /// Adds notes to the table
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string when data added successful</returns>
        public string AddNotes(NotesModel notesModel)
        {
            try
            {
                if (notesModel.Title != null || notesModel.Notes != null)
                {
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note Added Successfully !";
                }
                else
                {
                    return "Notes Not Added SuccessFully !";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the title or notes
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of data for title or Note</returns>
        public string UpdateTitleOrNote(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
                if (exists != null)
                {
                    exists.Notes = notesModel.Notes;
                    exists.Title = notesModel.Title;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    return "Note Updated Successfully !";
                }

                return "Note Not present! Add Note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the color
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of color</returns>
        public string UpdateColor(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
                if (exists != null)
                {
                    if (notesModel.Color != null)
                    {
                        exists.Color = notesModel.Color;
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

        /// <summary>
        /// Update Archive and returns a string
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns the string after updating archive</returns>
        public string UpdateArchive(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
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

        /// <summary>
        /// Updates the boolean value for Pin
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string after updating pin</returns>
        public string AddPin(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
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

        /// <summary>
        /// Updates the boolean value for Trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns> returns string on adding notes to trash after deletion</returns>
        public string DeleteAddToTrash(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.Is_Trash == false).FirstOrDefault();
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

        /// <summary>
        /// Gets notes
        /// </summary>
        /// <param name="userId">integer UserId</param>
        /// <returns>Returns a lit of retrieved notes</returns>
        public List<NotesModel> GetNotes(int userId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == false).ToList();
                if (exists.Count > 0)
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

        /// <summary>
        /// Restore to home from trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string on successful restore</returns>
        public string RestoreFromTrash(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.Is_Trash == true).FirstOrDefault();
                if (exists != null)
                {
                    exists.Is_Trash = false;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    return "Removed from trash !";
                }

                return "Note not present in trash";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete data from trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string on successful delete</returns>
        public string DeleteaNoteFromTrash(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId && x.Is_Trash == true).FirstOrDefault();
                if (exists != null)
                {
                    this.UserContext.Notes.Remove(exists);
                    this.UserContext.SaveChanges();
                    return "Deleted Data Successfully";
                }

                return "No Data Present";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empty the trash
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>string after empty trash</returns>
        public string EmptyTrash(int userId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == true).ToList();
                if (exists != null)
                {
                    this.UserContext.Notes.RemoveRange(exists);
                    this.UserContext.SaveChanges();
                    return "Trash Emptied";
                }

                return "Trash is empty!";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets remainder
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful remainder set</returns>
        public string SetRemainder(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
                if (exists != null) 
                {
                    exists.Remainder = notesModel.Remainder;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    return "Remainder Set"; 
                }

                return "Remainder Not Set";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes remainder
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string after removing the remainder</returns>
        public string DeleteRemainder(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).FirstOrDefault();
                if (exists != null)
                {
                    exists.Remainder = null;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                    return "Remainder Removed";
                }

                return "No Note present!";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> GetRemainderNotes(NotesModel notesModel)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == notesModel.UserId && x.Remainder != null).ToList();
                if (exists!=null)
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
