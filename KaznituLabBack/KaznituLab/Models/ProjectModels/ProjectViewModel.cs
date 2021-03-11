using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.ProjectModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateEndPlaned { get; set; }
        public decimal RequestBudget { get; set; }
        public decimal HaveBudget { get; set; }
        public int StagesCount { get; set; }
        public string Description { get; set; }
    }
    public class ProjectGetAllResponseModel : ProjectViewModel
    {
        public DictionaryModel ProjectStatus { get; set; }
    }
    public class ProjectGetResponseModel : ProjectGetAllResponseModel
    {
        public IEnumerable<ProjectContractViewModel> Contracts { get; set; }
        public IEnumerable<ProjectCustomerViewModel> Customers { get; set; }
        public IEnumerable<ProjectEmployeeViewModel> Employees { get; set; }
        public IEnumerable<ProjectFundingViewModel> Fundings { get; set; }
        public IEnumerable<ProjectRevenueViewModel> Revenues { get; set; }
        public IEnumerable<ProjectPatentViewModel> Patents { get; set; }
        public IEnumerable<ProjectCertificateRegistrationViewModel> CertificateRegistrations { get; set; }
    }
}
