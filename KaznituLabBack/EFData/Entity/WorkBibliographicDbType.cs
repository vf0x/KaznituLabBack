using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class WorkBibliographicDbType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WorkId { get; set; }
        public int BibliographicDbTypeId { get; set; }
        [ForeignKey("WorkId")]
        public virtual Work Work { get; set; }
        [ForeignKey("BibliographicDbTypeId")]
        public virtual BibliographicDbType BibliographicDbType { get; set; }
    }
}
