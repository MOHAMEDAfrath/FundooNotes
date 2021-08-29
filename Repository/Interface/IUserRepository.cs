﻿using FundooNotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel registerModel);
        bool Login(string email,string password);
    }
}
