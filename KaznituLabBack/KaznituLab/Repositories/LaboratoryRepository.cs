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
    public class LaboratoryRepository : Repository<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(KaznituLabContext context) : base(context)
        {

        }
        public IEnumerable<Laboratory> IncludedGetAll()
        {
            var data = _context.Laboratories
                .Include(l => l.LaboratoryEmployees)
                .Include(l => l.LaboratoryEqiupments)
                .ThenInclude(le => le.Equipment)
                .Include(l => l.LaboratoryServices)
                .Include(l => l.LaboratoryStatus)
                .Where(l => l.Deleted == false) ;
            return data;
        }
        public Laboratory IncludedGet(int Id)
        {
            var data = _context.Laboratories
                .Include(l => l.LaboratoryEmployees)
                .Include(l => l.LaboratoryEqiupments)
                .ThenInclude(le => le.Equipment)
                .Include(l => l.LaboratoryServices)
                .Include(l=> l.LaboratoryStatus)
                .Include(l=> l.LaboratoryProjects)
                .ThenInclude(lp=> lp.Project)
                .Where(l => l.Id == Id).FirstOrDefault();
            return data;
        }
        public IEnumerable<LaboratoryEmployee> GetEmployeeByLaboratoryId(int LaboratoryId)
        {
            var data = _context.LaboratoryEmployees.AsNoTracking().Where(le => le.LaboratoryId == LaboratoryId);
            return data;
        }
        public IEnumerable<LaboratoryEqiupment> GetEqiupmentByLaboratoryId(int LaboratoryId)
        {
            var data = _context.LaboratoryEqiupments.AsNoTracking().Where(le => le.LaboratoryId == LaboratoryId);
            return data;
        }
        public IEnumerable<LaboratoryService> GetServiceByLaboratoryId(int LaboratoryId)
        {
            var data = _context.LaboratoryServices.AsNoTracking().Where(le => le.LaboratoryId == LaboratoryId);
            return data;
        }
        public IEnumerable<LaboratoryProject> GetProjectByLaboratoryId(int LaboratoryId)
        {
            var data = _context.LaboratoryProjects.AsNoTracking().Where(lp => lp.LaboratoryId == LaboratoryId);
            return data;
        }
        //public IEnumerable<LaboratoryEmployee> GetDeleteEmployee(int LaboratoryId, List<int> EmployeeIds)
        //{
        //    var data = _context.LaboratoryEmployees.Where(le => le.LaboratoryId == LaboratoryId && !EmployeeIds.Contains(le.EmployeeId));
        //    return data;
        //}
        //public IEnumerable<LaboratoryEqiupment> GetDeleteEqiupment(int LaboratoryId, List<int> EqiupmentIds)
        //{
        //    var data = _context.LaboratoryEqiupments.Where(le => le.LaboratoryId == LaboratoryId && !EqiupmentIds.Contains(le.EquipmentId));
        //    return data;
        //}
        //public IEnumerable<LaboratoryService> GetDeleteService(int LaboratoryId, List<int> ServiceIds)
        //{
        //    var data = _context.LaboratoryServices.Where(s => s.LaboratoryId == LaboratoryId && !ServiceIds.Contains(s.Id));
        //    return data;
        //}
    }
}
