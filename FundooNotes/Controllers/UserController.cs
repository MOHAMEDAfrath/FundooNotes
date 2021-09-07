// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.Extensions.Logging;
    using global::Models;
    using StackExchange.Redis;

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
        /// ILogger logger
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class and create a object of IUserManager on runtime
        /// </summary>
        /// <param name="userManager">IUserManager userManager</param>
        /// <param name="logger">ILogger logger</param>
        public UserController(IUserManager userManager, ILogger<UserController> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
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
                this.logger.LogInformation(userData.FirstName + " " + userData.LastName + " is trying to register");
                string result = this.userManager.Register(userData);

                if (result == "Registration Successfull !")
                {
                    this.logger.LogInformation(userData.FirstName + " " + userData.LastName + " " + result);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    this.logger.LogInformation(userData.FirstName + " " + userData.LastName + " " + result);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception occured while using register " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Performs login and returns the status code as IActionResult
        /// </summary>
        /// <param name="loginDetails">LoginModel loginDetails</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                this.logger.LogInformation(loginDetails.EmailId + " is trying to Login");
                string result = this.userManager.Login(loginDetails);
                string token = this.userManager.GenerateToken(loginDetails.EmailId);
                if (result != "Login Failed ,Invalid Credentials !")
                {
                    this.logger.LogInformation(loginDetails.EmailId + " logged in successfully and the token generated is " + token);
                    ConnectionMultiplexer connectionMultiplier = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplier.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    string userId = database.StringGet("UserId");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Successful!", Data = result + " , Token : " + token });
                }
                else
                {
                    this.logger.LogInformation(loginDetails.EmailId + " " + result);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception occured while logging in " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Performs forgot password operation by sending email to the user
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPost]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                this.logger.LogInformation(email + "is using forgot password");
                string result = this.userManager.ForgotPassword(email);

                if (result == "Mail Sent Successfully, Please check your mail !")
                {
                    this.logger.LogInformation(result);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    this.logger.LogInformation(result);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception occured while using forgot password " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Resets the password
        /// </summary>
        /// <param name="resetModel">ResetModel resetModel</param>
        /// <returns>Below function returns the status code as IAction Result</returns>
        [HttpPut]
        [Route("api/resetPassword")]
        public IActionResult ResetPassword([FromBody] ResetModel resetModel)
        {
            try
            {
                this.logger.LogInformation(resetModel.EmailId + "is using reset password");
                bool result = this.userManager.ResetPassword(resetModel);

                if (result == true)
                {
                    this.logger.LogInformation("Password reseted Successfully for " + resetModel.EmailId);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reseted Successfully" });
                }
                else
                {
                    this.logger.LogInformation("Password Reset Failed!");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Failed!" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation("Exception occured while using reset password " + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
