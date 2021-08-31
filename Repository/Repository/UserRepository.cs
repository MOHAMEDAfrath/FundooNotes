// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes
{
    using System;
    using System.Linq;
    using System.Text;
    using Experimental.System.Messaging;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using global::Repository.Context;

    /// <summary>
    /// User Repository performs action with database,send email operation
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// User Context Objects
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        public UserRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }
        
        /// <summary>
        /// Adds the user data to the database
        /// </summary>
        /// <param name="userData">RegisterModel userData</param>
        /// <returns>Returns true if Register is successful</returns>
        public bool Register(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.Password = this.EncryptPassword(userData.Password);
                    this.UserContext.Users.Add(userData);
                    this.UserContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Login checks for the user in database and allows him to login
        /// </summary>
        /// <param name="email">string email</param>
        /// <param name="password">string password</param>
        /// <returns>returns true if login is successful</returns>
        public bool Login(string email, string password)
        {
            try
            {
                  string encodedPassword = this.EncryptPassword(password);
                    var loginUser = this.UserContext.Users.Where(x => x.EmailId == email && x.Password == encodedPassword).FirstOrDefault();
                    if (loginUser != null)
                    {
                        return true;
                    }
                
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
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
                return this.SendToMSMQ(email, "Hello");
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Send to MSMQ=>microsoft message queue
        /// </summary>
        /// <param name="email">string email</param>
        /// <param name="url">string password</param>
        /// <returns>Returns true if the message in the queue is sent successfully</returns>
        public bool SendToMSMQ(string email, string url)
        {
            MessageQueue msqueue;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msqueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msqueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            msqueue.Label = "url Link";
            msqueue.Send(message);
            return this.ReceiveFromMSMQ(email);
        }

        /// <summary>
        /// Receive from MSMQ=>microsoft message queue
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns true if the message in the queue is sent successfully</returns>
        public bool ReceiveFromMSMQ(string email)
        {
            return true;
        }
            
        /// <summary>
        /// Encryption using Base64
        /// </summary>
        /// <param name="password">string password</param>
        /// <returns>encoded password</returns>    
        public string EncryptPassword(string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(password);
            string encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }
    }
}
