using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.ProjectModels;

namespace KaznituLab.Services.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectGetAllResponseModel> GetAll();
        ProjectGetResponseModel Get(int Id);
        int Save(ProjectGetResponseModel model);
        void Delete(int Id);
    }
}
