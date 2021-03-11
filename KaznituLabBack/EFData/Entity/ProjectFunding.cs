using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class ProjectFunding
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public int CurrencyTypeId { get; set; }
        public int FinancingTypeId { get; set; }
        public string Description { get; set; }


        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("FinancingTypeId")]
        public virtual FinancingType FinancingType { get; set; }
        [ForeignKey("CurrencyTypeId")]
        public virtual CurrencyType CurrencyType { get; set; }
        public virtual ICollection<ProjectFundingStage> ProjectFundingStages { get; set; }
        public virtual ICollection<ProjectFundingCoFinancing> ProjectFundingCoFinancings { get; set; }
    }
}
