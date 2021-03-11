using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Helpers;
using KaznituLab.Models;
using KaznituLab.Models.EquipmentModels;
using KaznituLab.Models.Laboratory;
using KaznituLab.Repositories;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces;

namespace KaznituLab.Services
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IUnitOfWork Db;
        private readonly HrContext hrDb;
        public LaboratoryService(IUnitOfWork db, HrContext hrdb)
        {
            Db = db;
            hrDb = hrdb;
        }
        public IEnumerable<LaboratoryGetAllResponseModel> GetAll()
        {
            IEnumerable<LaboratoryGetAllResponseModel> res;
            var data = Db.Laboratories.IncludedGetAll();
            var depDict = hrDb.Departments.ToList();
            res = data.Select(c => new LaboratoryGetAllResponseModel()
            {
                Id = c.Id,
                Title = c.Title,
                FieldOfStudy = c.FieldOfStudy,
                Accreditation = c.Accreditation,
                PositionLaboratory = c.PositionLaboratory,
                LaboratoryPhotoName = c.LaboratoryPhotoName,
                Department = depDict.Where(d => d.Id == c.DepartmentId).Select(d => new DictionaryModel()
                {
                    Id = d.Id,
                    Title = d.Title
                }).FirstOrDefault(),
                Status = c.LaboratoryStatus != null ? new DictionaryModel()
                {
                    Id = c.LaboratoryStatus.Id,
                    Title = c.LaboratoryStatus.Title
                } : null
            });
            return res;
        }
        public LaboratoryGetResponseModel Get(int Id)
        {
            LaboratoryGetResponseModel res;
            var data = Db.Laboratories.IncludedGet(Id);
            var depDict = hrDb.Departments.ToList();
            var hrEmp = hrDb.Employees.ToList();
            var DirectorEmployee = hrEmp.FirstOrDefault(c => c.Id == data.DirectorEmployeeId);
            var Director = DirectorEmployee != null ? string.Concat(DirectorEmployee.LastName, " ", DirectorEmployee.FirstName, "", DirectorEmployee.MiddleName) : null;
            res = new LaboratoryGetResponseModel()
            {
                Id = data.Id,
                Title = data.Title,
                FieldOfStudy = data.FieldOfStudy,
                Accreditation = data.Accreditation,
                PositionLaboratory = data.PositionLaboratory,
                Address = data.Address,
                Office = data.Office,
                LocationPhotoName = data.LocationPhotoName,
                LaboratoryPhotoName = data.LaboratoryPhotoName,
                Department = depDict.Where(d => d.Id == data.DepartmentId).Select(d => new DictionaryModel()
                {
                    Id = d.Id,
                    Title = d.Title
                }).FirstOrDefault(),
                Status = data.LaboratoryStatus != null ? new DictionaryModel()
                {
                    Id = data.LaboratoryStatus.Id,
                    Title = data.LaboratoryStatus.Title
                } : null,
                Employees = from e in data.LaboratoryEmployees
                            join h in hrEmp on e.EmployeeId equals h.Id
                            select new AdvanceDictionaryModel() { Id = e.Id, Key = h.Id, Title = string.Concat(h.FirstName, " ", h.LastName, " ", h.MiddleName) },
                Services = data.LaboratoryServices.Select(ls => new DictionaryModel()
                {
                    Id = ls.Id,
                    Title = ls.Title
                }),
                Eqiupments = data.LaboratoryEqiupments.Select(le => new EquipmentViewModel()
                {
                    Id = le.Id,
                    EquipmentId = le.Equipment.Id,
                    EquipmentTitle = le.Equipment.Title,
                    EquipmentPhotoName = le.Equipment.PictureName,
                    EquipmentDestinations = le.Equipment.Destinations
                }),
                DirectorEmployee = data.DirectorEmployeeId != null ? new DictionaryModel()
                {
                    Id = data.DirectorEmployeeId.HasValue ? data.DirectorEmployeeId.Value : 0,
                    Title = Director

                } : null,
                Projects = data.LaboratoryProjects.Select(lp=> new DictionaryModel()
                {
                    Id = lp.ProjectId,
                    Title = lp.Project.Title
                })
            };
            return res;

        }
        public int SaveLaboratory(LaboratoryGetRequesetModel model)
        {
            LaboratoryDataRequesetModel resData = new LaboratoryDataRequesetModel();
            if (model.Data != null)
            {
                resData = model.GetLaboratory();
            }
            else throw new Exception("DATA IS NULL");

            if(model != null)
            {
                if (model.LabPhotoFileData != null)
                {
                    if(resData.LaboratoryPhotoName != null)
                    {
                        string path = Path.Combine(Environment.CurrentDirectory, "images", resData.LaboratoryPhotoName);
                        File.Delete(path);
                    }
                    resData.LaboratoryPhotoName = UploadImageHelper.UploadFile(model.LabPhotoFileData);
                }
                if (model.LabPhotoFileData != null)
                {
                    if (resData.LocationPhotoName != null)
                    {
                        string path = Path.Combine(Environment.CurrentDirectory, "images", resData.LocationPhotoName);
                        File.Delete(path);
                    }
                    resData.LocationPhotoName = UploadImageHelper.UploadFile(model.LocationPhotoFileData);
                }
            }

            var labRes = new Laboratory
            {
                Id = resData.Id,
                Title = resData.Title,
                FieldOfStudy = resData.FieldOfStudy,
                Accreditation = resData.Accreditation,
                PositionLaboratory = resData.PositionLaboratory,
                Address = resData.Address,
                Office = resData.Office,
                LocationPhotoName = resData.LocationPhotoName,
                LaboratoryPhotoName = resData.LaboratoryPhotoName,
                DepartmentId = resData.DepartmentId,
                LaboratoryStatusId = resData.StatusId,
                DirectorEmployeeId = resData.DirectorEmployeeId
            };

            Db.Laboratories.InsertOrUpdate(labRes);
            Db.Complete();

            var emp = Db.Laboratories.GetEmployeeByLaboratoryId(labRes.Id);

            if(emp != null)
            {
                var empDel = emp.Where(e => !resData.EmployeeIds.Contains(e.EmployeeId));
                Db.LaboratoryEmployees.RemoveRange(empDel);
            }

            if(resData.EmployeeIds != null && resData.EmployeeIds.Count() > 0)
            {
                var empIns = resData.EmployeeIds.Where(e => !emp.Select(em => em.EmployeeId).Contains(e));
                var empRes = empIns.Select(c => new LaboratoryEmployee()
                {
                    EmployeeId = c,
                    LaboratoryId = labRes.Id
                });
                Db.LaboratoryEmployees.InsertOrUpdateRange(empRes);
            }

            var eq = Db.Laboratories.GetEqiupmentByLaboratoryId(labRes.Id);
            if (eq != null)
            {
                var eqDel = eq.Where(e => !resData.EqiupmentIds.Contains(e.EquipmentId));
                Db.LaboratoryEqiupments.RemoveRange(eqDel);
            }
            if(resData.EqiupmentIds != null && resData.EqiupmentIds.Count() > 0)
            {
                var eqIns = resData.EqiupmentIds.Where(e => !eq.Select(em => em.EquipmentId).Contains(e));
                var eqiupRes = eqIns.Select(c => new LaboratoryEqiupment()
                {
                    EquipmentId = c,
                    LaboratoryId = labRes.Id
                });
                Db.LaboratoryEqiupments.InsertOrUpdateRange(eqiupRes);
            }

            
            var srv = Db.Laboratories.GetServiceByLaboratoryId(labRes.Id);

            if(srv != null)
            {
                var srvDel = srv.Where(s => !resData.EmployeeIds.Contains(s.Id));
                Db.LaboratoryServices.RemoveRange(srvDel);
            }

            if(resData.Services !=null && resData.Services.Count() > 0)
            {
                var serviceRes = resData.Services.Select(c => new EFData.Entity.LaboratoryService()
                {
                    Id = c.Id,
                    Laboratory = labRes,
                    Title = c.Title
                });
                Db.LaboratoryServices.InsertOrUpdateRange(serviceRes);
            }
             

            var lp = Db.Laboratories.GetProjectByLaboratoryId(labRes.Id);

            if(lp != null)
            {
                var lpDel = lp.Where(e => !resData.ProjectIds.Contains(e.ProjectId));
                Db.LaboratoryProjects.RemoveRange(lpDel);
            }
            var lpIns = resData.ProjectIds.Where(e => !lp.Select(q => q.ProjectId).Contains(e));

            if(resData.ProjectIds != null && resData.ProjectIds.Count() > 0)
            {
                var lpRes = lpIns.Select(c => new LaboratoryProject()
                {
                    ProjectId = c,
                    LaboratoryId = labRes.Id
                });
                Db.LaboratoryProjects.InsertOrUpdateRange(lpRes);
            }

            Db.Complete();
            return labRes.Id;

        }
        public void Delete(int Id)
        {
            var data = Db.Laboratories.Get(Id);
            data.Deleted = true;
            Db.Complete();
        }
    }
}
