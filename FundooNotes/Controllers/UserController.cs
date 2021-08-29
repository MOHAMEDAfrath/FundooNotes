﻿using FundooNotes.Managers.Interface;
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
        //Route checks the request url and performs the Register function
        //Below function returns the status code as IAction Result
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
        /// <summary>
        /// Performs login and returns the status code as IActionResult
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                bool result = this.userManager.Login(loginDetails);
                if(result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successfull !" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull ! Email or Password does not match" });
                }
            }catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
