using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class Employee
    {
        public Employee()
        {
            AcademicDegreeEmployees = new HashSet<AcademicDegree>();
            AcademicDegreeSupervisors = new HashSet<AcademicDegree>();
            EmployeeDetails = new HashSet<EmployeeDetail>();
            OrderEmployees = new HashSet<OrderEmployee>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Iin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsMale { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatorId { get; set; }
        public bool? CreatedInAd { get; set; }
        public string AduserName { get; set; }
        public bool? CreatedInSso { get; set; }

        public virtual ICollection<AcademicDegree> AcademicDegreeEmployees { get; set; }
        public virtual ICollection<AcademicDegree> AcademicDegreeSupervisors { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployees { get; set; }
    }
}
