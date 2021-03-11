using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.EmployeeModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IIN { get; set; }
        public string Department { get; set; }
    }
    public class EmployeeAcademicDegreeViewModel : EmployeeViewModel
    {
        public IEnumerable<DictionaryModel> AcademicDegrees { get; set; }
    }
}

