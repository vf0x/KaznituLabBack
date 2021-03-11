using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectCertificateRegistrationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public DateTime? IssueDate { get; set; }
        public string CopyrightHolder { get; set; }
    }
}
