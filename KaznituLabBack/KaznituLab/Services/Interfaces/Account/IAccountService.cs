using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.AccountModels;

namespace KaznituLab.Services.Interfaces.Account
{
    public interface IAccountService
    {
        Task<int> CreateUser(RegisterModel model);
    }
}
