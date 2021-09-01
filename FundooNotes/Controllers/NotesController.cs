// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
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
    /// NotesController class
    /// </summary>
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// IUserManager object
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class and create a object of INotesManager on runtime
        /// </summary>
        /// <param name="notesManager">INotesManager notesManager</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        /// <summary>
        /// Adds notes to the table
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string when data added successful</returns>
        [HttpPost]
        [Route("api/addorUpdateNote")]
        public IActionResult AddNotes([FromBody] NotesModel notesModel) 
        {
            try
            {
                string result = this.notesManager.AddNotes(notesModel);
                if (result == "Note Added Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                   return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the title or notes
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of data for title or Note</returns>
        [HttpPut]
        [Route("api/UpdateNote")]
        public IActionResult UpdateTitleOrNote([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.UpdateTitleOrNote(notesModel);
                if (result == "Note Updated Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the color
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns string on successful update of color</returns>
        [HttpPut]
        [Route("api/UpdateColor")]
        public IActionResult UpdateColor([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.UpdateColor(notesModel);
                if (result == "Color Added Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Archive and returns a string
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns the string after updating archive</returns>
        [HttpPut]
        [Route("api/archive")]
        public IActionResult UpdateArchive([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.UpdateArchive(notesModel);
                if (result == "Archived Successfully !" || result == "Removed from Archive")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the boolean value for Pin
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a string after updating pin</returns>
        [HttpPut]
        [Route("api/Pin")]
        public IActionResult AddPin([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.AddPin(notesModel);
                if (result == "Pinned Successfully !" || result == "Removed from Pin")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Updates the boolean value for Trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns> returns string on adding notes to trash after deletion</returns>
        [HttpPut]
        [Route("api/Trash")]
        public IActionResult DeleteAddToTrash([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.DeleteAddToTrash(notesModel);
                if (result == "Added to trash !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Gets notes
        /// </summary>
        /// <param name="userId">integer UserId</param>
        /// <returns>Returns a lit of retrieved notes</returns>
        [HttpPost]
        [Route("api/getNote")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                List<NotesModel> notes = this.notesManager.GetNotes(userId);
                if (notes != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Retrieved notes successful! " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No Notes present" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
