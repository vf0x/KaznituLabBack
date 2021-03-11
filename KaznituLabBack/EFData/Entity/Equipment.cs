using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using EFData.HrEntity;

namespace EFData.Entity
{
    public class Equipment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string PictureName { get; set; }
        [ForeignKey("EquipmentStatus")]
        public int? EquipmentStatusId { get; set; }
        public virtual ICollection<LaboratoryEqiupment> LaboratoryEqiupments { get; set; }
        public virtual EquipmentStatus EquipmentStatus { get; set; }
        public virtual ICollection<EquipmentTechnicalMaintenance> EquipmentTechnicalMaintenances { get; set; }
    }
}
