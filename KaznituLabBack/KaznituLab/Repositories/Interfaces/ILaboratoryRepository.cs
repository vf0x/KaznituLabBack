using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;

namespace KaznituLab.Repositories.Interfaces
{
    public interface ILaboratoryRepository : IRepository<Laboratory>
    {
        IEnumerable<Laboratory> IncludedGetAll();
        Laboratory IncludedGet(int Id);
        IEnumerable<LaboratoryEmployee> GetEmployeeByLaboratoryId(int LaboratoryId);
        IEnumerable<LaboratoryService> GetServiceByLaboratoryId(int LaboratoryId);
        IEnumerable<LaboratoryEqiupment> GetEqiupmentByLaboratoryId(int LaboratoryId);
        IEnumerable<LaboratoryProject> GetProjectByLaboratoryId(int LaboratoryId);
    }
}
