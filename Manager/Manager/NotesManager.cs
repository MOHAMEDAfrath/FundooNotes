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
    using global::Manager.Interface;
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
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of color</returns>
        public string UpdateColor(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.UpdateColor(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.UpdateArchive(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.AddPin(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.DeleteAddToTrash(notesModel);
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
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string on successful restore</returns>
        public string RestoreFromTrash(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.RestoreFromTrash(notesModel);
            }
            catch (Exception ex)
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
                return this.notesRepository.DeleteaNoteFromTrash(notesModel);
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
    }
}
