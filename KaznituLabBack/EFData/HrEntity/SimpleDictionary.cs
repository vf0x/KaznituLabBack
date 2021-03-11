using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class SimpleDictionary
    {
        public SimpleDictionary()
        {
            AcademicDegreeAcademicDegreeNavigations = new HashSet<AcademicDegree>();
            AcademicDegreeSpecialities = new HashSet<AcademicDegree>();
            EmployeeDetailCitizenships = new HashSet<EmployeeDetail>();
            EmployeeDetailEducationLanguages = new HashSet<EmployeeDetail>();
            EmployeeDetailEducations = new HashSet<EmployeeDetail>();
            EmployeeDetailEnglishLevels = new HashSet<EmployeeDetail>();
            EmployeeDetailMaritalStatuses = new HashSet<EmployeeDetail>();
            EmployeeDetailNationalities = new HashSet<EmployeeDetail>();
            EmployeeDetailPlaceOfBirthNavigations = new HashSet<EmployeeDetail>();
            EmployeeDetailPublishedScientificArticleIndustries = new HashSet<EmployeeDetail>();
            OrderEmployeeCancelingReasons = new HashSet<OrderEmployee>();
            OrderEmployeeHiringConditions = new HashSet<OrderEmployee>();
            OrderEmployeeTariffRates = new HashSet<OrderEmployee>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime? FromDate { get; set; }
        public string Code { get; set; }
        public string KkName { get; set; }
        public string TreeId { get; set; }
        public string BusinessCode { get; set; }
        public string RuName { get; set; }
        public string ParentCode { get; set; }
        public string EntryDate { get; set; }
        public string Version { get; set; }
        public string Versions { get; set; }
        public string EnName { get; set; }
        public bool? IsNew { get; set; }
        public string ToDate { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<AcademicDegree> AcademicDegreeAcademicDegreeNavigations { get; set; }
        public virtual ICollection<AcademicDegree> AcademicDegreeSpecialities { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailCitizenships { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailEducationLanguages { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailEducations { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailEnglishLevels { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailMaritalStatuses { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailNationalities { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailPlaceOfBirthNavigations { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetailPublishedScientificArticleIndustries { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployeeCancelingReasons { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployeeHiringConditions { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployeeTariffRates { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
