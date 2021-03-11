using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KaznituLab.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(KaznituLabContext context) : base(context)
        {
        }
        public Equipment IncludedGet(int Id)
        {
            return _context.Equipments
                .Include(e => e.LaboratoryEqiupments)
                .ThenInclude(le=> le.Laboratory)
                .Include(e=> e.EquipmentStatus)
                .Include(e=> e.EquipmentTechnicalMaintenances)
                .Where(e=> e.Id == Id)
                .FirstOrDefault();
        }
        public IEnumerable<Equipment> IncludedGetAll()
        {
            return _context.Equipments
                .Include(e => e.LaboratoryEqiupments)
                .ThenInclude(le => le.Laboratory)
                .Include(e => e.EquipmentStatus);
        }
        public IEnumerable<EquipmentTechnicalMaintenance> GetHaveMaintenance()
        {
            return _context.EquipmentTechnicalMaintenances
                .Include(etm => etm.Equipment)
                .Where(etm => etm.Equipment.EquipmentStatusId != 2 && etm.StartDate < DateTime.Now);
        }
        public IEnumerable<EquipmentTechnicalMaintenance> GetTechnicalMaintenancesByEquipmentId(int id)
        {
            return _context.EquipmentTechnicalMaintenances.AsNoTracking().Where(tm => tm.EquipmentId == id);
        }
    }
}
