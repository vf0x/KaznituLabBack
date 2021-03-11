using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectFundingCoFinancingViewModel
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public DictionaryModel CurrencyType { get; set; }
    }
}
