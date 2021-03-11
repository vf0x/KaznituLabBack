using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class LaboratoryService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title {get;set;}
        public int LaboratoryId { get; set; }
        [ForeignKey("LaboratoryId")]
        public virtual Laboratory Laboratory { get; set; }
    }
}
