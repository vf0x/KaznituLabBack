using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class ProjectFundingStage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectFundingId { get; set; }
        public string Number { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        [ForeignKey("ProjectFundingId")]
        public virtual ProjectFunding ProjectFunding { get; set; }

    }
}
