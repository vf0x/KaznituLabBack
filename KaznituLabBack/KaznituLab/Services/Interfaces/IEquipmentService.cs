using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;
using KaznituLab.Models.EquipmentModels;

namespace KaznituLab.Services.Interfaces
{
    public interface IEquipmentService
    {
        int SaveEquipment(EquipmentGetRequestModel model);
        IEnumerable<EquipmentGetAllResponseModel> GetAll();
        void Delete(int Id);
        EquipmentViewGetModel Get(int Id);
    }
}
