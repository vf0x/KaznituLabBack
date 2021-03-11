using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Models.AccountModels;
using KaznituLab.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace KaznituLab.Services.Account
{
    public class AccountService
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountService(KaznituLabContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<int> CreateUser(RegisterModel model)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = new User
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    IIN = model.IIN
                };

                var appUser = new AppUser()
                {
                    Email = model.Email,
                    UserId = user.Id,
                    UserName = model.Login
                };
                var res = await _userManager.CreateAsync(appUser, model.Password);
                var data = await _userManager.FindByNameAsync(model.Login);
                transactionScope.Complete();
            }
            return 1;
        }
    }
}
