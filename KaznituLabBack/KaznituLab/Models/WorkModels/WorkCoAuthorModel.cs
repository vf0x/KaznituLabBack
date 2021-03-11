using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.EmployeeModels;

namespace KaznituLab.Models.WorkModels
{
    public class WorkCoAuthorModel 
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public bool FromSU { get; set; }
    }
}
