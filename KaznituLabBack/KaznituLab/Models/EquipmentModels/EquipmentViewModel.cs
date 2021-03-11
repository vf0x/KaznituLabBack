using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaznituLab.Models.EquipmentModels
{
    public class EquipmentViewModel
    {
        public int? Id { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentTitle { get; set; }
        public string EquipmentPhotoName { get; set; }
        public string EquipmentDestinations { get; set; }
    }
}
