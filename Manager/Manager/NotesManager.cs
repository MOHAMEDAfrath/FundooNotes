// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Manager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using global::Manager.Interface;
    using Microsoft.AspNetCore.Http;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// class notes manager
    /// </summary>
    public class NotesManager : INotesManager
    {
        /// <summary>
        ///  INotesRepository notesRepository
        /// </summary>
        private readonly INotesRepository notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class and create a object of INotesRepository on run time
        /// </summary>
        /// <param name="notesRepository">INotesRepository notesRepository</param>
        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
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
                return this.notesRepository.AddNotes(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.UpdateTitleOrNote(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.UpdateColor(noteId, color);
            }
            catch (Exception ex)
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
                return this.notesRepository.UpdateArchive(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.AddPin(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.DeleteAddToTrash(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.GetNotes(userId);
            }
            catch (Exception ex)
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
                return this.notesRepository.RestoreFromTrash(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.DeleteaNoteFromTrash(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.EmptyTrash(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets remainder
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <param name="remainder">string remainder</param>
        ///  <param name="userId">integer userId</param>
        /// <returns>returns string on successful remainder set</returns>
        public string SetRemainder(int notesId, string remainder, int userId)
        {
            try
            {
                return this.notesRepository.SetRemainder(notesId, remainder, userId);
            }
            catch (Exception ex)
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
                return this.notesRepository.DeleteRemainder(notesId);
            }
            catch (Exception ex)
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
                return this.notesRepository.GetRemainderNotes(userId);
            }
            catch (Exception ex)
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
                return this.notesRepository.GetArchiveNotes(userId);
            }
            catch (Exception ex)
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
                return this.notesRepository.GetTrashNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds Image
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <param name="image">IFormFile image</param>
        /// <param name="userId">integer userId</param>
        /// <returns>returns string after successfully adding image</returns>
        public string AddImage(int notesId, IFormFile image, int userId)
        {
            try
            {
                return this.notesRepository.AddImage(notesId, image, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes Image
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns string after successfully removing image</returns>
        public string RemoveImage(int notesId)
        {
            try
            {
                return this.notesRepository.RemoveImage(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
