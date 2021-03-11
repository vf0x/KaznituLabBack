using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectFundingStageViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal Amount { get; set; }
    }
}
