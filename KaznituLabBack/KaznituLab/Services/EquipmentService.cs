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
using KaznituLab.Repositories.Interfaces;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces;

namespace KaznituLab.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork Db;
        private readonly HrContext hrDb;
        public EquipmentService(IUnitOfWork db, HrContext hrdb)
        {
            Db = db;
            hrDb = hrdb;
        }
        public int SaveEquipment(EquipmentGetRequestModel model)
        {
            var data = model.GetEquipment();

            if (model.PhotoFileData != null)
            {
                if (model != null)
                {
                    if (data.PictureName != null && data.PictureName.Length > 0)
                    {
                        string path = Path.Combine(Environment.CurrentDirectory, "images", data.PictureName);
                        File.Delete(path);
                    }
                }
                data.PictureName = UploadImageHelper.UploadFile(model.PhotoFileData);
            }
            var res = new Equipment
            {
                Id = data.Id,
                Title = data.Title,
                InventoryNumber = data.InventoryNumber,
                Destinations = data.Destinations,
                Year = data.Year,
                Zoom = data.Zoom,
                PowerVoltage = data.PowerVoltage,
                SafetyFuses = data.SafetyFuses,
                AmbientTemperature = data.AmbientTemperature,
                RelativeHumidity = data.RelativeHumidity,
                CertificateOfConformity = data.CertificateOfConformity,
                StateCheck = data.StateCheck,
                Passport = data.Passport,
                PictureName = data.PictureName,
                EquipmentStatusId = data.StatusId
            };
            Db.Equipments.InsertOrUpdate(res);
            Db.Complete();
            try
            {
                var tec = Db.Equipments.GetTechnicalMaintenancesByEquipmentId(res.Id);
                var empDel = tec.Where(t => !data.TechnicalMaintenances.Select(tm=> tm.Id).Contains(t.Id));
                var empIns = data.TechnicalMaintenances.Where(t => !tec.Select(tm => tm.Id).Contains(t.Id));

                Db.EquipmentTechnicalMaintenances.RemoveRange(empDel);

                var tech = data.TechnicalMaintenances != null ?
                data.TechnicalMaintenances.Select(tm => new EquipmentTechnicalMaintenance()
                {
                    Id = tm.Id,
                    EquipmentId = res.Id,
                    StartDate = tm.StartDate,
                    EndDate = tm.EndDate,
                    Description = tm.Description,
                    DescriptionAfterMaintenance = tm.DescriptionAfterMaintenance,
                    ServicePassed = tm.ServicePassed
                }) : null;
                if(tech != null) 
                {
                    Db.EquipmentTechnicalMaintenances.InsertOrUpdateRange(tech);
                    Db.Complete();
                }
            }
            catch(Exception e)
            {
                Db.Dispose();
                throw new Exception(e.Message);
            }
            return res.Id;
        }
        public IEnumerable<EquipmentGetAllResponseModel> GetAll()
        {
            IEnumerable<EquipmentGetAllResponseModel> res;
            var data =  Db.Equipments.IncludedGetAll();
            res = data.Select(d => new EquipmentGetAllResponseModel()
            {
                Id = d.Id,
                Title = d.Title,
                InventoryNumber = d.InventoryNumber,
                Destinations = d.Destinations,
                Year = d.Year,
                Zoom = d.Zoom,
                PowerVoltage = d.PowerVoltage,
                SafetyFuses = d.SafetyFuses,
                AmbientTemperature = d.AmbientTemperature,
                RelativeHumidity = d.RelativeHumidity,
                CertificateOfConformity = d.CertificateOfConformity,
                StateCheck = d.StateCheck,
                Passport = d.Passport,
                PictureName = d.PictureName,
                Laboratory = d.LaboratoryEqiupments.Select(le => new DictionaryModel()
                {
                    Id = le.Laboratory.Id,
                    Title = le.Laboratory.Title
                }),
                StatusTitle = d.EquipmentStatus != null ? d.EquipmentStatus.Title : null
            });
            return res;
        }
        public EquipmentViewGetModel Get(int Id)
        {
            var data = Db.Equipments.IncludedGet(Id);
            var res = new EquipmentViewGetModel
            {
                Id = data.Id,
                Title = data.Title,
                InventoryNumber = data.InventoryNumber,
                Destinations = data.Destinations,
                Year = data.Year,
                Zoom = data.Zoom,
                PowerVoltage = data.PowerVoltage,
                SafetyFuses = data.SafetyFuses,
                AmbientTemperature = data.AmbientTemperature,
                RelativeHumidity = data.RelativeHumidity,
                CertificateOfConformity = data.CertificateOfConformity,
                StateCheck = data.StateCheck,
                Passport = data.Passport,
                PictureName = data.PictureName,
                Laboratory = data.LaboratoryEqiupments.Select(le => new DictionaryModel()
                {
                    Id = le.Laboratory.Id,
                    Title = le.Laboratory.Title
                }),
                StatusId =  data.EquipmentStatusId,
                TechnicalMaintenances = data.EquipmentTechnicalMaintenances.Select(etm=> new EquipmentTechnicalMaintenanceViewModel()
                {
                    Id = etm.Id,
                    StartDate = etm.StartDate,
                    EndDate = etm.EndDate,
                    Description = etm.Description,
                    DescriptionAfterMaintenance = etm.DescriptionAfterMaintenance,
                    ServicePassed = etm.ServicePassed
                })
            };
            return res;
        }
        public void Delete(int Id)
        {
            Db.Equipments.RemoveById(Id);
            Db.Complete();
        }
    }
}
