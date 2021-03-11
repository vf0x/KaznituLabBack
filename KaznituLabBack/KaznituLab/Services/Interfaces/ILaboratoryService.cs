using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;
using KaznituLab.Models.Laboratory;

namespace KaznituLab.Services.Interfaces
{
    public interface ILaboratoryService
    {
        IEnumerable<LaboratoryGetAllResponseModel> GetAll();
        LaboratoryGetResponseModel Get(int Id);
        int SaveLaboratory(LaboratoryGetRequesetModel model);
        void Delete(int Id);
    }
}
