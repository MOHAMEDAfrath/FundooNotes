﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Managers.Interface;
    using FundooNotes.Models;
    using Microsoft.AspNetCore.Mvc;
    using global::Models;

    /// <summary>
    /// User controller class for login,register,forgot password
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// IUserManager object
        /// </summary>
        private readonly IUserManager userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class and create a object of IUserManager on runtime
        /// </summary>
        /// <param name="userManager">IUserManager userManager</param>
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Route checks the request url and performs the Register function
        /// </summary>
        /// <param name="userData">RegisterModel userData</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                bool result = this.userManager.Register(userData);

                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration Successfull !" });
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
        /// <param name="loginDetails">LoginModel loginDetails</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpGet]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                bool result = this.userManager.Login(loginDetails);

                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successfull !" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull ! Email or Password does not match" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Performs forgot password operation by sending email to the user
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpGet]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                bool result = this.userManager.ForgotPassword(email);

                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check your mail!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Email Not Sent" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
