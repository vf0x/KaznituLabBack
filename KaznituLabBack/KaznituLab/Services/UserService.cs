using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Models.AccountModels;
using KaznituLab.Repositories.Interfaces;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace KaznituLab.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        IUnitOfWork Db;
        public UserService(KaznituLabContext context , UserManager<AppUser> userManager, IUnitOfWork db)
        {
            _userManager = userManager;
            Db = db; 
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
                Db.Users.Add(user);
                Db.Complete();


                var appUser = new AppUser()
                {
                    Email = model.Email,
                    UserId = user.Id,
                    UserName = model.Login
                };
                var res = await _userManager.CreateAsync(appUser, model.Password);
                if (!res.Succeeded)
                {
                    throw new Exception("Не удалось создать пользователя");
                }
                var data = await _userManager.FindByNameAsync(model.Login);
                transactionScope.Complete();
            }
            return 1;
        }
    }
}
