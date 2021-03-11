using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFData.HrEntity;

namespace EFData.Entity
{
    public class Laboratory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FieldOfStudy { get; set; }
        public string Accreditation { get; set; }
        public string PositionLaboratory { get; set; }
        public string Address { get; set; }
        public string Office { get; set; }
        public string LocationPhotoName { get; set; }
        public int DepartmentId { get; set; }
        public string LaboratoryPhotoName { get; set; }
        public int? LaboratoryStatusId { get; set; }
        public int? DirectorEmployeeId { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<LaboratoryEmployee> LaboratoryEmployees { get; set; }
        public virtual ICollection<LaboratoryEqiupment> LaboratoryEqiupments { get; set; }
        public virtual ICollection<LaboratoryService> LaboratoryServices { get; set; }
        public virtual ICollection<LaboratoryProject> LaboratoryProjects { get; set; }
        public virtual LaboratoryStatus LaboratoryStatus { get; set; }
    }
}
