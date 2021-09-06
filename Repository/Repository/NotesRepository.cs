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
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    /// <summary>
    /// class NotesRepository
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        public readonly UserContext UserContext;

        public readonly IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        public NotesRepository(UserContext userContext,IConfiguration configuration)
        {
            this.UserContext = userContext;
            this.Configuration = configuration;
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
                if (notesModel.Title != null || notesModel.Notes != null || notesModel.Remainder != null || notesModel.Collaborator != null)
                {
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note Added Successfully !";
                }
                else
                {
                    return "Note Not Added SuccessFully !";
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
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesModel.NotesId).SingleOrDefault();
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
        /// <param name="noteId">integer noteId</param>
        /// <param name="color">string color</param>
        /// <returns>returns string on successful update of color</returns>
        public string UpdateColor(int noteId, string color)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (exists != null)
                {
                    if (color != null)
                    {
                        exists.Color = color;
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
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns the string after updating archive</returns>
        public string UpdateArchive(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Archive == true)
                    {
                        exists.Is_Archive = false;
                        message = "Note unarchived";
                    }
                    else
                    {
                        exists.Is_Archive = true;
                        message = "Note archived";
                        if (exists.Is_Pin == true)
                        {
                            exists.Is_Pin = false;
                            message = "Note unpinned and archived";
                        }
                    }  

                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                }
                else
                {
                    message = "Note Not present! Add Note";
                }

                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the boolean value for Pin
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string after updating pin</returns>
        public string AddPin(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Unpin Note";
                    }
                    else
                    {
                        exists.Is_Pin = true;
                        message = "Pinned";
                        if (exists.Is_Archive == true)
                        {
                            exists.Is_Archive = false;
                            message = "Note unarchived and pinned";
                        }
                    }

                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                }
                else
                {
                    message = "Note Not present! Add Note";
                }

                return message;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the boolean value for Trash
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns> returns string on adding notes to trash after deletion</returns>
        public string DeleteAddToTrash(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.Is_Trash == false).SingleOrDefault();
                string message = string.Empty;
                if (exists != null)
                {
                    exists.Is_Trash = true;
                    message = "Note trashed";

                    if (exists.Is_Pin == true)
                    {
                        exists.Is_Pin = false;
                        message = "Note unpinned and trashed";
                    }

                    exists.Remainder = null;
                    this.UserContext.Notes.Update(exists);
                    this.UserContext.SaveChanges();
                }
                else
                {
                    message = "Note Not present! Add Note";
                }

                return message;
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
                var userNotes = new List<NotesModel>();
                var userEmail = this.UserContext.Users.Where(x => x.UserId == userId).Select(x => x.EmailId).SingleOrDefault();
                 userNotes = (from notes in this.UserContext.Notes
                                join colab in this.UserContext.Collaborators
                                on notes.NotesId equals colab.NotesId
                                where colab.ColEmail == userEmail
                                select notes).ToList();
                if (userNotes.Count > 0)
                {
                    var notes = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == false).ToList();
                    foreach (var note in notes)
                    {
                        userNotes.Add(note);
                    }
                }
                else
                {
                    userNotes = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == false).ToList();
                }

                if (userNotes.Count > 0)
                {
                    return userNotes;
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
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string on successful restore</returns>
        public string RestoreFromTrash(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.Is_Trash == true).SingleOrDefault();
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
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string on successful delete</returns>
        public string DeleteaNoteFromTrash(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.Is_Trash == true).SingleOrDefault();
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
        /// <param name="notesId">integer notesId</param>
        /// <param name="remainder">string remainder</param>
        /// <returns>returns string on successful remainder set</returns>
        public string SetRemainder(int notesId, string remainder)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (exists != null) 
                {
                    exists.Remainder = remainder;
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
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns string after removing the remainder</returns>
        public string DeleteRemainder(int notesId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
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

        /// <summary>
        /// Get Remainder Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        public List<NotesModel> GetRemainderNotes(int userId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Remainder != null).ToList();
                if (exists != null)
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
        /// Get Archive Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        public List<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == false && x.Is_Archive == true).ToList();
                if (exists != null)
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
        /// Get Trash Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        public List<NotesModel> GetTrashNotes(int userId)
        {
            try
            {
                var exists = this.UserContext.Notes.Where(x => x.UserId == userId && x.Is_Trash == true).ToList();
                if (exists != null)
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

        public string AddImage(int notesId, IFormFile image)
        {
            try
            {
                var exist = this.UserContext.Notes.Find(notesId);
                if (exist != null)
                {
                    Account account = new Account
                    (
                        this.Configuration["CloudinaryAccount:CloudName"],
                        this.Configuration["CloudinaryAccount:APIKey"],
                        this.Configuration["CloudinaryAccount:APISecret"]
                    );
                    Cloudinary cloudinary = new Cloudinary(account);
                    var uploadFile = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, image.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadFile);
                    var uploadedImage = uploadResult.Url.ToString();
                    exist.Image = uploadedImage;
                    this.UserContext.Notes.Update(exist);
                    this.UserContext.SaveChanges();
                    return "Image added";
                }
                return "Not Notes Present";
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
