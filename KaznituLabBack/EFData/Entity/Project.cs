using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateEndPlaned { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal RequestBudget { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal HaveBudget { get; set; }
        public int ProjectStatusId { get; set; }
        public int StagesCount { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<ProjectContract> ProjectContracts { get; set; }
        public virtual ICollection<ProjectCustomer> ProjectCustomers { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public virtual ICollection<ProjectFunding> ProjectFundings { get; set; }
        public virtual ICollection<ProjectRevenue> ProjectRevenues { get; set; }
        public virtual ICollection<ProjectPatent> ProjectPatents { get; set; }
        public virtual ICollection<ProjectCertificateRegistration> ProjectCertificateRegistrations { get; set; }

    }
}
