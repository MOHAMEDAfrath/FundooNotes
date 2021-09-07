// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// class LabelController
    /// </summary>
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// ILabelManager LabelManager
        /// </summary>
        public readonly ILabelManager LabelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class and create a object of ILabelManager on runtime
        /// </summary>
        /// <param name="labelManager">ILabelManager labelManager</param>
        public LabelController(ILabelManager labelManager)
        {
            this.LabelManager = labelManager;
        }

        /// <summary>
        /// Adds label
        /// </summary>
        /// <param name="label">LabelModel label</param>
        /// <returns>returns IActionResult Status Code after successfully adding label without notesId</returns>
        [HttpPost]
        [Route("api/addLabel")]
        public IActionResult AddLabel([FromBody] LabelModel label)
        {
            try
            {
                string result = this.LabelManager.AddLabel(label);
                if (result == "Added Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a Label from Home
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a IActionResult Status Code after deleting from home</returns>
        [HttpDelete]
        [Route("api/DeleteMainLabel")]
        public IActionResult DeleteLabel(int userId, string labelName)
        {
            try
            {
                string result = this.LabelManager.DeleteLabel(userId, labelName);
                if (result == "Deleted Label")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit label name
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <param name="newLabelName">string newLabelName</param>
        /// <returns>returns a IActionResult Status Code after editing label</returns>
        [HttpPut]
        [Route("api/editLabel")]
        public IActionResult EditLabel(int userId, string labelName, string newLabelName)
        {
            try
            {
                string result = this.LabelManager.EditLabel(userId, labelName, newLabelName);
                if (result != "Label not present")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets Label Based on userId
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>returns a IActionResult Status Code for getting labels based on userID</returns>
        [HttpPost]
        [Route("api/GetLabel")]
        public IActionResult GetLabel(int userId)
        {
            try
            {
                var result = this.LabelManager.GetLabel(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "Retrieved Success", Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add Label from Notes
        /// </summary>
        /// <param name="labelModel">LabelModel labelModel</param>
        /// <returns>returns a IActionResult Status Code after adding label from notes</returns>
        [HttpPost]
        [Route("api/AddLabelToNote")]
        public IActionResult AddNotesLabel([FromBody] LabelModel labelModel)
        {
            try
            {
                string result = this.LabelManager.AddNotesLabel(labelModel);
                if (result == "Added Label To Note")
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a label from note
        /// </summary>
        /// <param name="labelId">integer labelId</param>
        /// <returns>returns a string after deleting a label from note</returns>
        [HttpPost]
        [Route("api/DeleteaLabelFromNote")]
        public IActionResult DeleteaLabelFromNote(int labelId)
        {
            try
            {
                string result = this.LabelManager.DeleteALabelFromNote(labelId);
                if (result == "Deleted Label From Note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get Label By Notes
        /// </summary>
        /// <param name="notesId">integer notesId</param>
        /// <returns>returns a list of label by notes</returns>
        [HttpPost]
        [Route("api/GetLabelByNote")]
        public IActionResult GetLabelByNoteId(int notesId)
        {
            try
            {
                var result = this.LabelManager.GetLabelByNote(notesId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "Retrieved Label", Data = result });
                }

                return this.BadRequest(new ResponseModel<List<string>>() { Status = false, Message = "Retrieved Label Failed" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Display notes for a particular label
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <param name="labelName">string labelName</param>
        /// <returns>returns a list of notes based on label</returns>
        [HttpPost]
        [Route("api/GetNotesByLabel")]
        public IActionResult GetNotesByLabel(int userId, string labelName)
        {
            try
            {
                var result = this.LabelManager.DisplayNotesBasedOnLabel(userId, labelName);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<NotesModel>>() { Status = true, Message = "Retrieved Notes", Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Retrieved Notes Failed" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
