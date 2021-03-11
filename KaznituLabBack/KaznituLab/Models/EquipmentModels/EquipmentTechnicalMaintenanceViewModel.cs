using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.EquipmentModels
{
    public class EquipmentTechnicalMaintenanceViewModel
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string DescriptionAfterMaintenance { get; set; }
        public bool ServicePassed { get; set; }
    }
}
