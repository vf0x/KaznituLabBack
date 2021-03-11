using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    public class BaseController : ControllerBase
    {
        protected string UserId
        {
            get
            {
                return  User.FindFirst("ID").Value;
            }
        }
        protected int LabUserId
        {
            get
            {
                return int.Parse(User.FindFirst("UserID").Value);
            }
        }
    }
}
