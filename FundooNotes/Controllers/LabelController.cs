using Manager.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LabelController : ControllerBase
    {
        public readonly ILabelManager LabelManager;

        public LabelController(ILabelManager labelManager)
        {
            this.LabelManager = labelManager;
        }
        
        [HttpPost]
        [Route("api/addLabel")]
        public IActionResult AddLabel([FromBody] LabelModel label)
        {
            try
            {
                string result = this.LabelManager.AddLabel(label);
                if(result == "Added Label")
                {
                    return this.Ok(new ResponseModel<string>() {Status = true, Message=result });
                }
                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteMainLabel")]
        public IActionResult DeleteLabel(int userId, string labelName)
        {
            try
            {
                string result = this.LabelManager.DeleteLabel(userId, labelName);
                if(result == "Deleted Label")
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

        [HttpPut]
        [Route("api/editLabel")]
        public IActionResult EditLabel(int userId,string labelName, string newLabelName)
        {
            try
            {
                string result = this.LabelManager.EditLabel(userId, labelName, newLabelName);
                if(result == "Updated Label")
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
    }
}
