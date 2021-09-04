using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

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
    }
}
