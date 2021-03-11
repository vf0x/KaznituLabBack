using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class AcademicDegree
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? AcademicDegreeId { get; set; }
        public int? SupervisorId { get; set; }
        public string Issuer { get; set; }
        public string ProtectionPlace { get; set; }
        public int? SpecialityId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual SimpleDictionary AcademicDegreeNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SimpleDictionary Speciality { get; set; }
        public virtual Employee Supervisor { get; set; }
    }
}
