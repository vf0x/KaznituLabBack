using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;

namespace KaznituLab.Repositories.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IEquipmentRepository Equipments { get; }
        ILaboratoryRepository Laboratories { get; set; }
        IProjectRepository Project { get; set; }
        IWorkRepository Works { get; set; }



        //
        IRepository<EquipmentTechnicalMaintenance> EquipmentTechnicalMaintenances { get; set; }
        IRepository<LaboratoryEmployee> LaboratoryEmployees { get; set; }
        IRepository<LaboratoryEqiupment> LaboratoryEqiupments { get; set; }
        IRepository<LaboratoryService> LaboratoryServices { get; set; }
        IRepository<LaboratoryProject> LaboratoryProjects { get; set; }
        IRepository<ProjectContract> ProjectContracts { get; set; }
        IRepository<ProjectCustomer> ProjectCustomers { get; set; }
        IRepository<ProjectEmployee> ProjectEmployees { get; set; }
        IRepository<WorkCoAuthor> WorkCoAuthors { get; set; }
        IRepository<ProjectCertificateRegistration> ProjectCertificateRegistrations { get; set; }
        IRepository<ProjectFunding> ProjectFundings { get; set; }
        IRepository<ProjectFundingStage> ProjectFundingStages { get; set; }
        IRepository<ProjectFundingCoFinancing> ProjectFundingCoFinancings { get; set; }
        IRepository<ProjectPatent> ProjectPatents { get; set; }
        IRepository<ProjectRevenue> ProjectRevenues { get; set; }
        int Complete();

    }
}
