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
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
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
