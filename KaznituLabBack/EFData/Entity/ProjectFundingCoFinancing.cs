using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class ProjectFundingCoFinancing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectFundingId { get; set; }
        public string Source { get; set; }
        public int CurrencyTypeId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        [ForeignKey("CurrencyTypeId")]
        public virtual CurrencyType CurrencyType { get; set; }
        [ForeignKey("ProjectFundingId")]
        public virtual ProjectFunding ProjectFunding { get; set; }
    }
}
