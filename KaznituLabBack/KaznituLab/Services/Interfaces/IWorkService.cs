using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.WorkModels;

namespace KaznituLab.Services.Interfaces
{
    public interface IWorkService
    {
        IEnumerable<WorkGetAllResponseModel> GetAll();
        WorkGetResponseModel Get(int Id);
        int Save(WorkRequestModel model);
        void Delete(int Id);
    }
}
