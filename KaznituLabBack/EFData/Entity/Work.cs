using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SourceTitle { get; set; }
        public int AuthorId { get; set; }
        public int WorkTypeId { get; set; }
        public int ReleaseYear { get; set; }
        public string Doi { get; set; }
        public string Issn { get; set; }
        public string Essn { get; set; }
        public string Isbn { get; set; }
        public bool PublishedMonRK { get; set; }
        public bool Deleted { get; set; }
        [ForeignKey("WorkTypeId")]
        public virtual WorkType WorkType { get; set; }
        public virtual ICollection<WorkBibliographicDbType> WorkBibliographicDbTypes { get; set; }
        public virtual ICollection<WorkCoAuthor> WorkCoAuthors { get; set; }
    }
}
