using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Models;
using KaznituLab.Models.ProjectModels;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaznituLab.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork Db;
        private readonly HrContext hrDb;
        public ProjectService(IUnitOfWork db, HrContext hrdb)
        {
            Db = db;
            hrDb = hrdb;
        }
        public IEnumerable<ProjectGetAllResponseModel> GetAll()
        {
            IEnumerable<ProjectGetAllResponseModel> res;            
            var data = Db.Project.IncludedGetAll();

            res = data.Select(d => new ProjectGetAllResponseModel()
            {
                Id = d.Id,
                Title = d.Title,
                DateStart = d.DateStart,
                DateEnd = d.DateEnd,
                DateEndPlaned = d.DateEndPlaned,
                RequestBudget = d.RequestBudget,
                HaveBudget = d.HaveBudget,
                ProjectStatus = d.ProjectStatus != null ? new DictionaryModel()
                {
                    Id = d.ProjectStatus.Id,
                    Title = d.ProjectStatus.Title
                } : null,
                StagesCount = d.StagesCount,
                Description = d.Description
            });
            return res;
        }
        public ProjectGetResponseModel Get(int Id)
        {
            var res = new ProjectGetResponseModel();
            var data = Db.Project.IncludedGet(Id);
            var hrEmp = hrDb.Employees
                .Include(e => e.EmployeeDetails).ToList();

            res = new ProjectGetResponseModel()
            {
                Id = data.Id,
                Title = data.Title,
                DateStart = data.DateStart,
                DateEnd = data.DateEnd,
                DateEndPlaned = data.DateEndPlaned,
                RequestBudget = data.RequestBudget,
                HaveBudget = data.HaveBudget,
                StagesCount = data.StagesCount,
                Description = data.Description,
                ProjectStatus = data.ProjectStatus != null ? new DictionaryModel()
                {
                    Id = data.ProjectStatus.Id,
                    Title = data.ProjectStatus.Title
                } : null,
                Contracts = data.ProjectContracts.Select(pc=> new ProjectContractViewModel()
                {
                    Id = pc.Id,
                    Title = pc.Title,
                    Number = pc.Number,
                    ContractСonclusions = pc.ContractСonclusions,
                    ValidityPriod = pc.ValidityPriod
                }),
                Customers = data.ProjectCustomers.Select(pc=> new ProjectCustomerViewModel()
                {
                    Id = pc.Id,
                    BIN = pc.BIN,
                    Name = pc.Name
                }),
                Employees = data.ProjectEmployees != null?  from pe in data.ProjectEmployees
                            join h in hrEmp on pe.EmployeeId equals h.Id
                            select new ProjectEmployeeViewModel() 
                            { 
                                Id = pe.Id ,
                                EmployeeId = pe.EmployeeId,
                                Role = pe.Role,
                                FullName = string.Concat(h.FirstName, " ", h.LastName, " ", h.MiddleName),
                                IsTeacher = h.EmployeeDetails.FirstOrDefault().IsPp == null ? false : h.EmployeeDetails.FirstOrDefault().IsPp.Value,
                            }: null,
                Fundings = data.ProjectFundings != null ? data.ProjectFundings.Select(pf => new ProjectFundingViewModel()
                {
                    Id = pf.Id,
                    Title = pf.Title,
                    Amount = pf.Amount,
                    Description = pf.Description,
                    CurrencyType = pf.CurrencyType != null ? new DictionaryModel()
                    {
                        Id = pf.CurrencyType.Id,
                        Title = pf.CurrencyType.Title
                    } : null,
                    FinancingType = pf.FinancingType != null ? new DictionaryModel()
                    {
                        Id = pf.FinancingType.Id,
                        Title = pf.FinancingType.Title
                    } : null,
                    FundingCoFinancings = pf.ProjectFundingCoFinancings.Select(cf => new ProjectFundingCoFinancingViewModel()
                    {
                        Id = cf.Id,
                        Source = cf.Source,
                        Amount = cf.Amount,
                        CurrencyType = cf.CurrencyType != null ? new DictionaryModel()
                        {
                            Id = cf.CurrencyType.Id,
                            Title = cf.CurrencyType.Title
                        } : null
                    }),
                    FundingStages = pf.ProjectFundingStages.Select(ft=> new ProjectFundingStageViewModel()
                    {
                        Id = ft.Id,
                        Number = ft.Number,
                        DateStart = ft.DateStart,
                        DateEnd = ft.DateEnd,
                        Amount = ft.Amount
                    })
                }) : null,
                Revenues = data.ProjectRevenues.Select(r=> new ProjectRevenueViewModel()
                {
                    Id = r.Id,
                    Year = r.Year,
                    Amount = r.Amount
                }),
                Patents = data.ProjectPatents.Select(p=> new ProjectPatentViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Type = p.Type,
                    Number = p.Number,
                    IssueDate = p.IssueDate,
                    ExpirationDate = p.ExpirationDate,
                    TeretoryFacilities = p.TeretoryFacilities,
                    CopyrightHolder = p.CopyrightHolder,
                    Author = p.Author
                }),
                CertificateRegistrations = data.ProjectCertificateRegistrations.Select(cr=> new ProjectCertificateRegistrationViewModel()
                {
                    Id = cr.Id,
                    Title = cr.Title,
                    Type = cr.Type,
                    Number = cr.Number,
                    IssueDate = cr.IssueDate,
                    CopyrightHolder = cr.CopyrightHolder
                })
            };
            return res;
        }
        public int Save(ProjectGetResponseModel model)
        {
            var projRes = new Project()
            {
                Id = model.Id,
                Title = model.Title,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                DateEndPlaned = model.DateEndPlaned,
                RequestBudget = model.RequestBudget,
                HaveBudget = model.HaveBudget,
                StagesCount = model.StagesCount,
                Description = model.Description,
                ProjectStatusId = model.ProjectStatus.Id
            };
            Db.Project.InsertOrUpdate(projRes);

            var contRes = model.Contracts.Select(c => new ProjectContract()
            {
                Id = c.Id,
                Project = projRes,
                Title = c.Title,
                Number = c.Number,
                ContractСonclusions = c.ContractСonclusions,
                ValidityPriod = c.ValidityPriod
            });

            Db.ProjectContracts.InsertOrUpdateRange(contRes);

            var customRes = model.Customers.Select(c => new ProjectCustomer()
            {
                Id = c.Id,
                Project = projRes,
                BIN = c.BIN,
                Name = c.Name
            });

            Db.ProjectCustomers.InsertOrUpdateRange(customRes);

            var empRes = model.Employees.Select(e=> new ProjectEmployee()
            {
                Id = e.Id,
                Project = projRes,
                EmployeeId = e.EmployeeId,
                Role = e.Role
            });
            Db.ProjectEmployees.InsertOrUpdateRange(empRes);
            //Db.Complete();

            foreach (var item in model.Fundings)
            {
                var fundRes = new ProjectFunding()
                {
                    Id = item.Id,
                    Project = projRes,
                    Title = item.Title,
                    Amount = item.Amount,
                    CurrencyTypeId = item.CurrencyType.Id,
                    FinancingTypeId = item.FinancingType.Id,
                    Description = item.Description,
                };
                Db.ProjectFundings.InsertOrUpdate(fundRes);

                var cofRes = item.FundingCoFinancings.Select(cf => new ProjectFundingCoFinancing()
                {
                    Id = cf.Id,
                    ProjectFunding = fundRes,
                    Source = cf.Source,
                    Amount = cf.Amount,
                    CurrencyTypeId = cf.CurrencyType.Id
                });
                Db.ProjectFundingCoFinancings.InsertOrUpdateRange(cofRes);

                var stageRes = item.FundingStages.Select(fs => new ProjectFundingStage()
                {
                    Id = fs.Id,
                    ProjectFunding = fundRes,
                    Number = fs.Number,
                    DateStart = fs.DateStart,
                    DateEnd = fs.DateEnd,
                    Amount = fs.Amount
                });
                Db.ProjectFundingStages.InsertOrUpdateRange(stageRes);
            }

            var revRes = model.Revenues.Select(r => new ProjectRevenue()
            {
                Id = r.Id,
                Project = projRes,
                Year = r.Year,
                Amount = r.Amount
            });
            Db.ProjectRevenues.InsertOrUpdateRange(revRes);

            var patRes = model.Patents.Select(p => new ProjectPatent()
            {
                Id = p.Id,
                Project = projRes,
                Title = p.Title,
                Type = p.Type,
                Number = p.Number,
                IssueDate = p.IssueDate,
                ExpirationDate = p.ExpirationDate,
                TeretoryFacilities = p.TeretoryFacilities,
                CopyrightHolder = p.CopyrightHolder,
                Author = p.Author
            });

            Db.ProjectPatents.InsertOrUpdateRange(patRes);

            var certRes = model.CertificateRegistrations.Select(cr => new ProjectCertificateRegistration()
            {
                Id = cr.Id,
                Project = projRes,
                Title = cr.Title,
                Type = cr.Type,
                Number = cr.Number,
                IssueDate = cr.IssueDate,
                CopyrightHolder = cr.CopyrightHolder
            });

            Db.ProjectCertificateRegistrations.InsertOrUpdateRange(certRes);

            Db.Complete();

            return projRes.Id;
        }
        public void Delete(int Id)
        {
            var data = Db.Project.Get(Id);
            data.Deleted = true;
            Db.Complete();
        }
    }
}
