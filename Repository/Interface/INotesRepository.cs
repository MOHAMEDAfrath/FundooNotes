// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
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
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of color</returns>
        string UpdateColor(NotesModel notesModel);

        /// <summary>
        /// Update Archive and returns a string
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns the string after updating archive</returns>
        string UpdateArchive(NotesModel notesModel);

        /// <summary>
        /// Updates the boolean value for Pin
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string after updating pin</returns>
        string AddPin(NotesModel notesModel);

        /// <summary>
        /// Updates the boolean value for Trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns> returns string on adding notes to trash after deletion</returns>
        string DeleteAddToTrash(NotesModel notesModel);

        /// <summary>
        /// Gets notes
        /// </summary>
        /// <param name="userId">integer UserId</param>
        /// <returns>Returns a lit of retrieved notes</returns>
        List<NotesModel> GetNotes(int userId);

        /// <summary>
        /// Restore to home from trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string on successful restore</returns>
        string RestoreFromTrash(NotesModel notesModel);
    }
}
