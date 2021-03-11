using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectContractViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTime? ContractСonclusions { get; set; }
        public DateTime? ValidityPriod { get; set; }
    }
}
