// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohamed Afrath S"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using FundooNotes.Models;
    using FundooNotes.Repository.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using global::Models;
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
        /// IConfiguration object
        /// </summary>
        public readonly IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="userContext">UserContext userContext</param>
        /// <param name="configuration">IConfiguration configuration</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.UserContext = userContext;
            this.Configuration = configuration;
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
                var exist = this.UserContext.Users.Where(x => x.EmailId == userData.EmailId).FirstOrDefault();
                if (exist == null)
                {
                    if (userData != null)
                    {
                        userData.Password = this.EncryptPassword(userData.Password);
                        this.UserContext.Users.Add(userData);
                        this.UserContext.SaveChanges();
                        return "Registration Successfull !";
                    }

                    return "Registraion Unsuccessfull !";
                }

                return "Email Already Exists! Please Login";
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
        public string Login(string email, string password)
        {
            try
            {
                  string encodedPassword = this.EncryptPassword(password);
                    var loginUser = this.UserContext.Users.Where(x => x.EmailId == email && x.Password == encodedPassword).FirstOrDefault();
                    if (loginUser != null)
                    { 
                        return loginUser.UserId + " , " + loginUser.FirstName + " , " + loginUser.LastName + " , " + loginUser.EmailId + " , " + loginUser.Password;
                    }
                
                return "Login Failed ,Invalid Credentials !";
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
        public string ForgotPassword(string email)
        {
            try
            {
                var exist = this.UserContext.Users.Where(x => x.EmailId == email).FirstOrDefault();
                if (exist != null)
                {
                    if (this.SendToMSMQ(email, "Hello"))
                    {
                        return "Mail Sent Successfully, Please check your mail !";
                    }

                    return "Email Not Sent";
                }
                else
                {
                    return "Email not Exists ! Please Register ! ";
                }
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
            msqueue.Label = "url-Link";
            msqueue.Send(message);
            if (this.SendEmail(email))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Receive from MSMQ=>microsoft message queue
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns true if the message in the queue is sent successfully</returns>
        public string ReceiveFromMSMQ(string email)
        {
            var receiveQueue = new MessageQueue(@".\Private$\MyQueue");
            var receiveMsg = receiveQueue.Receive();
            receiveMsg.Formatter = new BinaryMessageFormatter();
            string linkToBeSent = receiveMsg.Body.ToString();
            return linkToBeSent;
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

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="userData">ResetModel userData</param>
        /// <returns>Returns true if the password is successfully reset</returns>
        public bool ResetPassword(ResetModel userData)
        {
            try
            {
                if (userData != null)
                {
                    var user = this.UserContext.Users.Where(x => x.EmailId == userData.EmailId).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = this.EncryptPassword(userData.Password);
                        this.UserContext.Users.Update(user);
                        this.UserContext.SaveChanges();
                        return true;
                    }
                }

                return false;
            }
            catch (ArgumentNullException ex)
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
            byte[] key = Encoding.UTF8.GetBytes(this.Configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                new Claim(ClaimTypes.Email, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);  
        }

        /// <summary>
        /// Send the link for the forgot password to the user
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>Returns true if the message in the queue is sent successfully</returns>
        private bool SendEmail(string email)
        {
            string message = this.ReceiveFromMSMQ(email);
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mailMessage.From = new MailAddress("fundoo.notes2021@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Link to reset your password for Fundoo notes";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fundoo.notes2021@gmail.com", "fundoo2021");
            smtp.Send(mailMessage);
            return true;
        }
    }
}
