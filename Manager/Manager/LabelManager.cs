// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
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
    /// class LabelManager
    /// </summary>
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// ILabelRepository LabelRepository;
        /// </summary>
        public readonly ILabelRepository LabelRepository;

        /// <summary>
        ///  Initializes a new instance of the <see cref="LabelManager"/> class and create a object of ILabelRepository on runtime
        /// </summary>
        /// <param name="labelRepository">ILabelRepository labelRepository</param>
        public LabelManager(ILabelRepository labelRepository)
        {
            this.LabelRepository = labelRepository;
        }

        /// <summary>
        /// Adds label
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns string after successfully adding label without notesId</returns>
        public string AddLabel(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.AddLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete a Label from Home
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a string after deleting from home</returns>
        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                return this.LabelRepository.DeleteLabel(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edit label name
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns a string after editing label</returns>
        public string EditLabel(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.EditLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets Label Based on userId
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns a list for getting labels based on userID</returns>
        public List<string> GetLabel(int userId)
        {
            try
            {
                return this.LabelRepository.GetLabel(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Label from Notes
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns a string after adding label from notes</returns>
        public string AddNotesLabel(LabelModel labelModel)
        {
            try
            {
                return this.LabelRepository.AddNotesLabel(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete a label from note
        /// </summary>
        /// <param name="labelId">integer labelId</param>
        /// <returns>returns a string after deleting a label from note</returns>
        public string DeleteALabelFromNote(int labelId)
        {
            try
            {
                return this.LabelRepository.DeleteALabelFromNote(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Label By Notes
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a list of label by notes</returns>
        public List<string> GetLabelByNote(int notesId)
        {
            try
            {
                return this.LabelRepository.GetLabelByNote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Display notes for a particular label
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a list of notes based on label</returns>
        public List<NotesModel> DisplayNotesBasedOnLabel(int userId, string labelName)
        {
            try
            {
                return this.LabelRepository.DisplayNotesBasedOnLabel(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
