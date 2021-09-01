// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Interface
{
    using FundooNotes.Models;
    using global::Models;

    /// <summary>
    /// Interface UserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Register Method
        /// </summary>
        /// <param name="registerModel">RegisterModel registerModel</param>
        /// <returns>returns a boolean value</returns>
        string Register(RegisterModel registerModel);

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="email">string email</param>
        /// <param name="password">string password</param>
        /// <returns>returns a boolean value</returns>
        string Login(string email, string password);

        /// <summary>
        /// Forgot password method
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>returns a boolean value</returns>
        bool ForgotPassword(string email);

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
