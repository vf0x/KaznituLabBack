using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.EmployeeModels;

namespace KaznituLab.Services.Interfaces.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAll();
        IEnumerable<EmployeeAcademicDegreeViewModel> GetEmployee(int Id);
    }
}
