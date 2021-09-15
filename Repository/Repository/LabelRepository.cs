// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
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
    /// class LabelRepository 
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// UserContext UserContext
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepository"/> class and create a object of UserContext on runtime
        /// </summary>
        /// <param name="userContext">(UserContext userContext</param>
        public LabelRepository(UserContext userContext)
        {
            this.UserContext = userContext;
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
                var exist = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId && x.NotesId == null).SingleOrDefault();
                if (exist == null) 
                {
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    return "Added Label";
                }

                return "Label Already Exists";
            }
            catch (ArgumentNullException ex)
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
                var exists = this.UserContext.Labels.Where(x => x.LabelName == labelName && x.UserId == userId).ToList();
                if (exists.Count > 0)
                {
                    this.UserContext.Labels.RemoveRange(exists);
                    this.UserContext.SaveChanges();
                    return "Deleted Label";
                }

                    return "No Label Present";
            }
            catch (ArgumentNullException ex)
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
                string message = "Label not present"; 
                var exist = this.UserContext.Labels.Where(x => x.LabelId == labelModel.LabelId).Select(x=>x.LabelName).SingleOrDefault();
                var existOldLabel = this.UserContext.Labels.Where(x => x.LabelName == exist && x.UserId == labelModel.UserId).ToList();
                var labelExists = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName && x.UserId == labelModel.UserId && x.NotesId == null).SingleOrDefault();
                if (existOldLabel.Count > 0)
                {
                    message = "Updated Label";
                    if (labelExists != null)
                    {
                        this.UserContext.Labels.Remove(labelExists);
                        this.UserContext.SaveChanges();
                        message = "Merge the '" + exist + "' label with the '"
                           + labelModel.LabelName + "' label? All notes labeled with '" + exist
                           + "' will be labeled with '" + labelModel.LabelName + "', and the '" + exist +
                           "' label will be deleted.";
                    }

                    existOldLabel.ForEach(x => x.LabelName = labelModel.LabelName);
                    this.UserContext.Labels.UpdateRange(existOldLabel);
                    this.UserContext.SaveChanges();   
                }

                return message;
            }
            catch (ArgumentNullException ex)
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
                var exist = this.UserContext.Labels.Where(x => x.UserId == userId).Select(x => x.LabelName).Distinct().ToList();
                if (exist.Count > 0)
                {
                    return exist;
                }

                return null;
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
                var exists = this.UserContext.Labels.Where(x => x.LabelName == labelModel.LabelName && labelModel.NotesId == x.NotesId).SingleOrDefault();
                if (exists == null)
                {
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    labelModel.LabelId = 0;                 
                    labelModel.NotesId = null;
                    this.AddLabel(labelModel);
                    return "Added Label To Note";
                }

                return null;
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
                var existsLabel = this.UserContext.Labels.Where(x => x.LabelId == labelId).SingleOrDefault();
                if (existsLabel != null)
                {
                    this.UserContext.Labels.Remove(existsLabel);
                    this.UserContext.SaveChanges();
                    return "Deleted Label From Note";
                }

                return "Failed";  
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
        public List<LabelModel> GetLabelByNote(int notesId)
        {
            try
            {
                var exists = this.UserContext.Labels.Where(x => x.NotesId == notesId).ToList();
                if (exists.Count > 0)
                {
                    return exists;
                }

                return null;
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
                var exists = (from notes in this.UserContext.Notes
                             join label in this.UserContext.Labels
                             on notes.NotesId equals label.NotesId
                             where userId == label.UserId && label.LabelName == labelName 
                              select notes).ToList();
                if (exists.Count > 0)
                {
                    return exists;
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
