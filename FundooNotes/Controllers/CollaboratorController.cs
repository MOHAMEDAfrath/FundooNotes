// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// class CollaboratorController
    /// </summary>
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// ICollaboratorManager CollaboratorManager
        /// </summary>
        public readonly ICollaboratorManager CollaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController"/> class
        /// </summary>
        /// <param name="collaboratorManager">ICollaboratorManager collaboratorManager</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.CollaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Adds collaborator
        /// </summary>
        /// <param name="collaboratorModel">CollaboratorModel collaboratorModel</param>
        /// <returns>returns IActionResult status code after adding collaborator</returns>
        [HttpPost]
        [Route("api/addCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorModel)
        {
            try
            {
               string result = this.CollaboratorManager.AddCollaborator(collaboratorModel);
                if (result == "Collaborator Added!")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = collaboratorModel.ColEmail });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete collaborator
        /// </summary>
        /// <param name="colId">integer colId</param>
        /// <returns>returns IActionResult status code after deleting collaborator</returns>
        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public IActionResult RemoveCollaborator(int colId)
        {
            try
            {
                string result = this.CollaboratorManager.RemoveCollaborator(colId);
                if (result == "Removed Collaborator")
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
        /// Get collaborator
        /// </summary>
        /// <param name="noteId">integer noteId</param>
        /// <returns>returns IActionResult status code after get collaborator</returns>
        [HttpPost]
        [Route("api/getCollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                List<string> result = this.CollaboratorManager.GetCollaborator(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<List<string>>() { Status = true, Message = "Retrieved Collaborator", Data = result });
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
