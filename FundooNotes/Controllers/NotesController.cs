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
        /// <returns>returns a IActionResult as status code when data added successful</returns>
        [HttpPost]
        [Route("api/addNote")]
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
        /// <returns>returns IActionResult as status code on successful update of data for title or Note</returns>
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
        /// <returns>returns IActionResult as status code on successful update of color</returns>
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
        /// <returns>returns the IActionResult as status code after updating archive</returns>
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
        /// <returns>returns a IActionResult as status code after updating pin</returns>
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
        /// <returns> returns IActionResult as status code on adding notes to trash after deletion</returns>
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
        /// <returns>IActionResult as status code</returns>
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

        /// <summary>
        /// Restore from trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns a IAction on successful restore</returns>
        [HttpPut]
        [Route("api/Trash/Restore")]
        public IActionResult RestoreFromTrash([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.RestoreFromTrash(notesModel);
                if (result == "Removed from trash !")
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
        /// Delete from trash
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>IActionResult as Status Code</returns>
        [HttpDelete]
        [Route("api/Trash/Delete")]
        public IActionResult DeleteaNoteFromTrash([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.DeleteaNoteFromTrash(notesModel);
                if (result == "Deleted Data Successfully")
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
        /// Empty the trash
        /// </summary>
        /// <param name="userId">integer userId</param>
        /// <returns>IActionResult status code</returns>
        [HttpDelete]
        [Route("api/Trash/EmptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            try
            {
                string result = this.notesManager.EmptyTrash(userId);
                if (result == "Trash Emptied")
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
        /// Sets remainder
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns IActionResult as status code on successful remainder set</returns>
        [HttpPost]
        [Route("api/Remainder")]
        public IActionResult SetRemainder([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.SetRemainder(notesModel);
                if (result == "Remainder Set")
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
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Deletes remainder
        /// </summary>
        /// <param name="notesModel">NotesModel notesModel</param>
        /// <returns>returns IActionResult status code after removing the remainder</returns>
        [HttpPut]
        [Route("api/RemainderDelete")]
        public IActionResult DeleteRemainder([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.DeleteRemainder(notesModel);
                if (result == "Remainder Removed")
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
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
