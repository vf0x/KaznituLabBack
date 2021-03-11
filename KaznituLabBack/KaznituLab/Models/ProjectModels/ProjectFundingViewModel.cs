using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectFundingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DictionaryModel CurrencyType { get; set; }
        public DictionaryModel FinancingType { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProjectFundingCoFinancingViewModel> FundingCoFinancings { get; set; }
        public IEnumerable<ProjectFundingStageViewModel> FundingStages { get; set; }
    }
}
