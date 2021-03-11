using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;

namespace KaznituLab.Repositories.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Equipment IncludedGet(int Id);
        IEnumerable<Equipment> IncludedGetAll();
        IEnumerable<EquipmentTechnicalMaintenance> GetHaveMaintenance();
        IEnumerable<EquipmentTechnicalMaintenance> GetTechnicalMaintenancesByEquipmentId(int id);
    }
}
