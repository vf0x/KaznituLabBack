using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class WorkCoAuthor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WorkId { get; set; }
        public int EmployeeId { get; set; }
        public bool FromSU { get; set; }
        [ForeignKey("WorkId")]
        public virtual Work Work { get; set; }
    }
}
