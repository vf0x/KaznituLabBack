using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KaznituLab.Models.EquipmentModels
{
    public class RequestEquipmentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string InventoryNumber { get; set; }
        public string Destinations { get; set; }
        public int Year { get; set; }
        public string Zoom { get; set; }
        public string PowerVoltage { get; set; }
        public string SafetyFuses { get; set; }
        public string AmbientTemperature { get; set; }
        public string RelativeHumidity { get; set; }
        public string CertificateOfConformity { get; set; }
        public string StateCheck { get; set; }
        public string Passport { get; set; }
        public IFormFile PhotoFileData { get; set; }
        public string PictureName { get; set; }
        public bool IsPhotoChange { get; set; }
    }
}
