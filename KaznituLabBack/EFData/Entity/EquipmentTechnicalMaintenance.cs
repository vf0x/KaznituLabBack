using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class EquipmentTechnicalMaintenance
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string DescriptionAfterMaintenance { get; set; }
        public bool ServicePassed { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
    }
}
