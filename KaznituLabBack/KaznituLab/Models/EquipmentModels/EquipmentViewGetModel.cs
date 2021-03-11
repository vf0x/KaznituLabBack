using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KaznituLab.Models.EquipmentModels
{
    public class EquipmentViewGetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
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
        public string PictureName { get; set; }
        public IEnumerable<DictionaryModel> Laboratory { get; set; }
        public int? StatusId { get; set; }
        public IEnumerable<EquipmentTechnicalMaintenanceViewModel> TechnicalMaintenances { get; set; }

    }
    public class EquipmentGetRequestModel
    {
        public string Data { get; set; }
        public IFormFile PhotoFileData { get; set; }
        public EquipmentViewGetModel GetEquipment() 
        {
            return JsonConvert.DeserializeObject<EquipmentViewGetModel>(Data);
        }
    }
    public class EquipmentGetAllResponseModel : EquipmentViewGetModel
    {
        public string StatusTitle { get; set; }
    }
}
