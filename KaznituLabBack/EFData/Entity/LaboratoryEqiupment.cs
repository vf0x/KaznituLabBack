using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class LaboratoryEqiupment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LaboratoryId { get; set; }
        public int EquipmentId { get; set; }
        [ForeignKey("LaboratoryId")]
        public virtual Laboratory Laboratory { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
    }
}
