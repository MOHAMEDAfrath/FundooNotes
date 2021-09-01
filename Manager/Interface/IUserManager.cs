// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Managers.Interface
{
    using FundooNotes.Models;
    using global::Models;

    /// <summary>
    /// Interface IUserManager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Adds the user data to the database
        /// </summary>
        /// <param name="registerModel">RegisterModel userData</param>
        /// <returns>Returns string if Register is successful</returns>
        string Register(RegisterModel registerModel);

        /// <summary>
        /// Login checks for the user in database and allows him to login
        /// </summary>
        /// <param name="loginDetails">LoginModel loginDetails</param>
        /// <returns>returns string if login is successful</returns>
        string Login(LoginModel loginDetails);

        /// <summary>
        /// Forgot password method performs sending mail to user to reset their password
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns string if mail sent successful else false</returns>
        string ForgotPassword(string email);

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="userData">ResetModel userData</param>
        /// <returns>Returns true if the password is successfully reset</returns>
        bool ResetPassword(ResetModel userData);

        /// <summary>
        /// Generates tokens
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns the token when user logins</returns>
        string GenerateToken(string email);
    }
}
