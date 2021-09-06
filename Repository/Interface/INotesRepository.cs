// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Models;
    
    /// <summary>
    /// INotesRepository Interface
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Adds notes to the table
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string when data added successful</returns>
        string AddNotes(NotesModel notesModel);

        /// <summary>
        /// Updates the title or notes
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of data for title or Note</returns>
        string UpdateTitleOrNote(NotesModel notesModel);

        /// <summary>
        /// Updates the color
        /// </summary>
        /// <param name="noteId">integer noteId</param>
        /// <param name="color">string color</param>
        /// <returns>returns string on successful update of color</returns>
        string UpdateColor(int noteId, string color);

        /// <summary>
        /// Update Archive and returns a string
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns the string after updating archive</returns>
        string UpdateArchive(int notesId);

        /// <summary>
        /// Updates the boolean value for Pin
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string after updating pin</returns>
        string AddPin(int notesId);

        /// <summary>
        /// Updates the boolean value for Trash
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns> returns string on adding notes to trash after deletion</returns>
        string DeleteAddToTrash(int notesId);

        /// <summary>
        /// Gets notes
        /// </summary>
        /// <param name="userId">integer UserId</param>
        /// <returns>Returns a lit of retrieved notes</returns>
        List<NotesModel> GetNotes(int userId);

        /// <summary>
        /// Restore to home from trash
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string on successful restore</returns>
        string RestoreFromTrash(int notesId);

        /// <summary>
        /// Delete data from trash
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a string on successful delete</returns>
        string DeleteaNoteFromTrash(int notesId);

        /// <summary>
        /// Empty the trash
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>string after empty trash</returns>
        string EmptyTrash(int userId);

        /// <summary>
        /// Sets remainder
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <param name="remainder">string remainder</param>
        /// <returns>returns string on successful remainder set</returns>
        string SetRemainder(int notesId, string remainder);

        /// <summary>
        /// Deletes remainder
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns string after removing the remainder</returns>
        string DeleteRemainder(int notesId);

        /// <summary>
        /// Get Remainder Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        List<NotesModel> GetRemainderNotes(int userId);

        /// <summary>
        /// Get Archive Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        List<NotesModel> GetArchiveNotes(int userId);

        /// <summary>
        /// Get Trash Notes
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns list as result</returns>
        List<NotesModel> GetTrashNotes(int userId);

        /// <summary>
        /// Adds Image
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <param name="image">IFormFile image</param>
        /// <returns>returns string after successfully adding image</returns>
        string AddImage(int notesId, IFormFile image);

        /// <summary>
        /// Removes Image
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns string after successfully removing image</returns>
        string RemoveImage(int notesId);
    }
}
