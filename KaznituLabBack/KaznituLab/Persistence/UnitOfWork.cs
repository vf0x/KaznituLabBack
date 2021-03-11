using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Repositories;
using KaznituLab.Repositories.Interfaces;
using KaznituLab.Repositories.Interfaces.UnitOfWork;

namespace KaznituLab.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private KaznituLabContext db;

        public UnitOfWork(KaznituLabContext context)
        {
            db = context;
            Users = new UserRepository(db);
            Equipments = new EquipmentRepository(db);
            Laboratories = new LaboratoryRepository(db);
            Project = new ProjectRepository(db);
            Works = new WorkRepository(db);

            //

            EquipmentTechnicalMaintenances = new Repository<EquipmentTechnicalMaintenance>(db);
            LaboratoryEmployees = new Repository<LaboratoryEmployee>(db);
            LaboratoryEqiupments = new Repository<LaboratoryEqiupment>(db);
            LaboratoryServices = new Repository<LaboratoryService>(db);
            LaboratoryProjects = new Repository<LaboratoryProject>(db);
            ProjectContracts = new Repository<ProjectContract>(db);
            ProjectCustomers = new Repository<ProjectCustomer>(db);
            ProjectEmployees = new Repository<ProjectEmployee>(db);
            WorkCoAuthors = new Repository<WorkCoAuthor>(db);
            ProjectCertificateRegistrations = new Repository<ProjectCertificateRegistration>(db);
            ProjectFundings = new Repository<ProjectFunding>(db);
            ProjectFundingStages = new Repository<ProjectFundingStage>(db);
            ProjectFundingCoFinancings = new Repository<ProjectFundingCoFinancing>(db);
            ProjectPatents = new Repository<ProjectPatent>(db);
            ProjectRevenues = new Repository<ProjectRevenue>(db);
        }
        public IUserRepository Users { get; set; }
        public IEquipmentRepository Equipments { get; set; }
        public ILaboratoryRepository Laboratories { get; set; }
        public IProjectRepository Project { get; set; }
        public IWorkRepository Works { get; set; }

        //

        public IRepository<LaboratoryEmployee> LaboratoryEmployees { get; set; }
        public IRepository<LaboratoryEqiupment> LaboratoryEqiupments { get; set; }
        public IRepository<LaboratoryService> LaboratoryServices { get; set; }
        public IRepository<LaboratoryProject> LaboratoryProjects { get; set; }
        public IRepository<ProjectContract> ProjectContracts { get; set; }
        public IRepository<ProjectCustomer> ProjectCustomers { get; set; }
        public IRepository<ProjectEmployee> ProjectEmployees { get; set; }
        public IRepository<EquipmentTechnicalMaintenance> EquipmentTechnicalMaintenances { get; set; }
        public IRepository<WorkCoAuthor> WorkCoAuthors { get; set; }
        public IRepository<ProjectCertificateRegistration> ProjectCertificateRegistrations { get; set; }
        public IRepository<ProjectFunding> ProjectFundings { get; set; }
        public IRepository<ProjectFundingStage> ProjectFundingStages { get; set; }
        public IRepository<ProjectFundingCoFinancing> ProjectFundingCoFinancings { get; set; }
        public IRepository<ProjectPatent> ProjectPatents { get; set; }
        public IRepository<ProjectRevenue> ProjectRevenues { get; set; }
        public int Complete()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
