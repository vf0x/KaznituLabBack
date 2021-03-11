using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.EmployeeModels;
using KaznituLab.Services.Interfaces.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private IEmployeeService _empService;
        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }
        [HttpGet("GetEmployees")]
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _empService.GetAll();
        }
        [HttpGet("GetEmployee")]
        public IEnumerable<EmployeeAcademicDegreeViewModel> GetEmployee(int Id)
        {
            return _empService.GetEmployee(Id);
        }
    }
}
