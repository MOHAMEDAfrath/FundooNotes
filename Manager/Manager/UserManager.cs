// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Managers.Manager
{
    using System;
    using FundooNotes.Managers.Interface;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using global::Models;

    /// <summary>
    /// UserManager Class manages the operation done by the user
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// IUserRepository type object
        /// </summary>
        public readonly IUserRepository UserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class and create object for UserManager on run time
        /// </summary>
        /// <param name="userRepository">IUserRepository userRepository</param>
        public UserManager(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        /// <summary>
        /// Adds the user data to the database
        /// </summary>
        /// <param name="userData">RegisterModel userData</param>
        /// <returns>Returns true if Register is successful</returns>
        public string Register(RegisterModel userData)
        {
            try
            {
                return this.UserRepository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Login checks for the user in database and allows him to login
        /// </summary>
        /// <param name="loginDetails">LoginModel loginDetails</param>
        /// <returns>returns true if login is successful</returns>
        public string Login(LoginModel loginDetails)
        {
            try
            {
               return this.UserRepository.Login(loginDetails.EmailId, loginDetails.Password); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgot password method performs sending mail to user to reset their password
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns true if mail sent successful else false</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                return this.UserRepository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="userData">ResetModel userData</param>
        /// <returns>Returns true if the password is successfully reset</returns>
        public bool ResetPassword(ResetModel userData)
        {
            try
            {
                return this.UserRepository.ResetPassword(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generates tokens
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns the token when user logins</returns>
        public string GenerateToken(string email)
        {
            try
            {
                return this.UserRepository.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
