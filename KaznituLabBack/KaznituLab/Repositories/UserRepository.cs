using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Repositories.Interfaces;

namespace KaznituLab.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(KaznituLabContext context) : base(context)
        {

        }

    }
}
