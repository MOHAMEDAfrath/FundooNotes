namespace FundooNotes.Controllers
{
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
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


        [HttpPost]
        [Route("api/addorUpdateNote")]
        public IActionResult AddNotes([FromBody] NotesModel NotesModel) 
        {
            try
            {
                string result = this.notesManager.AddNotes(NotesModel);
                if(result == "Note Added Successfully !")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                   return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

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

        [HttpPost]
        [Route("api/getNote")]
        public IActionResult GetNotes(int UserId)
        {
            try
            {
                List<NotesModel> notes = this.notesManager.GetNotes(UserId);
                if (notes!=null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Retrieved notes successful! " });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No Notes present"}) ;
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }

        }
    }
}
