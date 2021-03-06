// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace Manager.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// interface ILabelManager
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Adds label
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns string after successfully adding label without notesId</returns>
        string AddLabel(LabelModel labelModel);

        /// <summary>
        /// Delete a Label from Home
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a string after deleting from home</returns>
        string DeleteLabel(int userId, string labelName);

        /// <summary>
        /// Edit label name
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns a string after editing label</returns>
        public string EditLabel(LabelModel labelModel);

        /// <summary>
        /// Gets Label Based on userId
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns a list for getting labels based on userID</returns>
        List<string> GetLabel(int userId);

        /// <summary>
        /// Add Label from Notes
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns a string after adding label from notes</returns>
        string AddNotesLabel(LabelModel labelModel);

        /// <summary>
        /// Delete a label from note
        /// </summary>
        /// <param name="labelId">integer labelId</param>
        /// <returns>returns a string after deleting a label from note</returns>
        string DeleteALabelFromNote(int labelId);

        /// <summary>
        /// Get Label By Notes
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a list of label by notes</returns>
        List<LabelModel> GetLabelByNote(int notesId);

        /// <summary>
        /// Display notes for a particular label
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a list of notes based on label</returns>
        List<NotesModel> DisplayNotesBasedOnLabel(int userId, string labelName);
    }
}
