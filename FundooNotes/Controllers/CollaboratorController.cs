using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace FundooNotes.Controllers
{
    public class CollaboratorController : ControllerBase
    {
        public readonly ICollaboratorManager collaboratorManager; 
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }


        [HttpPost]
        [Route("api/addCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorModel)
        {
            try
            {
               string result = this.collaboratorManager.AddCollaborator(collaboratorModel);
                if(result == "Collaborator Added!")
                {
                    return this.Ok(new ResponseModel<string>() { Status=true, Message=result,Data = collaboratorModel.ColEmail});
                }
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public IActionResult RemoveCollaborator(int colId)
        {
            try
            {
                string result = this.collaboratorManager.RemoveCollaborator(colId);
                if (result == "Removed Collaborator")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/getCollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                List<string> result = this.collaboratorManager.GetCollaborator(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "Retrieved Collaborator",Data = result });
                }
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed to retrieve" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
