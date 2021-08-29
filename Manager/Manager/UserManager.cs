using FundooNotes.Managers.Interface;
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Managers.Manager
{
    public class UserManager : IUserManager
    {
        public readonly IUserRepository userRepository;
        //Initializes on runtime
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        //Checks whether the data is successfully added to the repository 
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.userRepository.Register(userData);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
