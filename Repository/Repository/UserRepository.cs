﻿using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //Adds the user data to the data 
        public bool Register(RegisterModel userData)
        {
            try{
                if (userData != null)
                {
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
    }
}
