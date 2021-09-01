﻿namespace FundooNotes.Controllers
{
    using Manager.Interface;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;
    using System;

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
    }
}
