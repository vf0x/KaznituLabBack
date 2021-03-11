using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using KaznituLab.Models.EmployeeModels;
using KaznituLab.Services.Interfaces.Employee;
using Microsoft.EntityFrameworkCore;

namespace KaznituLab.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HrContext hrDb;
        public EmployeeService(HrContext hrdb)
        {
            hrDb = hrdb;
        }
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            IEnumerable<EmployeeViewModel> res;
            var data = hrDb.OrderEmployees
                .Include(oe => oe.Employee)
                .Include(oe => oe.Department)
                .Where(oe => oe.IsMainPosition == true);
            res = data.Select(c => new EmployeeViewModel
            {
                Id = c.Employee.Id,
                FullName = string.Concat(c.Employee.LastName," ", c.Employee.FirstName," ", c.Employee.MiddleName),
                IIN = c.Employee.Iin,
                Department = c.Department.Title
            });
            return res;
        }
        public IEnumerable<EmployeeAcademicDegreeViewModel> GetEmployee(int Id)
        {
            IEnumerable<EmployeeAcademicDegreeViewModel> res;
            var data = hrDb.Employees
                .Include(e => e.OrderEmployees.Where(oe => oe.IsMainPosition == true))
                .ThenInclude(oe => oe.Department)
                .Include(e => e.AcademicDegreeEmployees)
                .ThenInclude(ad => ad.AcademicDegreeNavigation)
                .Where(e => e.Id == Id);
            res = data.Select(c => new EmployeeAcademicDegreeViewModel
            {
                Id = c.Id,
                FullName = string.Concat(c.LastName, " ", c.FirstName, " ", c.MiddleName),
                IIN = c.Iin,
                Department = c.OrderEmployees.FirstOrDefault().Department.Title,
                AcademicDegrees = c.AcademicDegreeEmployees.Select(ad=> new Models.DictionaryModel()
                {
                    Id = ad.Id,
                    Title = ad.AcademicDegreeNavigation.Title
                })
            });
            return res;
        }
    }
}
