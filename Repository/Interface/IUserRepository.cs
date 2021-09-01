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

        bool ResetPassword(ResetModel userData);
    }
}
