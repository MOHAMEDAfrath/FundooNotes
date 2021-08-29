using FundooNotes.Managers.Interface;
using FundooNotes.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{

    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                bool result = this.userManager.Register(userData);
                if(result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status=true,Message="Registration Successfull !"});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration Unsuccessfull !" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
