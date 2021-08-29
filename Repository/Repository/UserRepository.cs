using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly UserContext userContext;
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        //Adds the user data to the database
        public bool Register(RegisterModel userData)
        {
            try{
                if (userData != null)
                {
                    userData.Password = encryptPassword(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;

            }catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Encryption using Base64
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encryptPassword(string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(password);
            string encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }
    }
}
