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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(KaznituLabContext context) : base(context)
        {

        }
        public IEnumerable<Project> IncludedGetAll()
        {
            var data = _context.Projects
                .Include(p => p.ProjectStatus)
                .Where(p => p.Deleted == false);
            return data;
        }
        public Project IncludedGet(int Id)
        {
            var data = _context.Projects
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectContracts)
                .Include(p => p.ProjectCustomers)
                .Include(p => p.ProjectEmployees)
                .Include(p => p.ProjectRevenues)
                .Include(p => p.ProjectPatents)
                .Include(p => p.ProjectCertificateRegistrations)

                .Include(p=> p.ProjectFundings)
                .ThenInclude(pf=> pf.ProjectFundingCoFinancings)

                .Include(p => p.ProjectFundings)
                .ThenInclude(pf=> pf.ProjectFundingStages)

                .Include(p => p.ProjectFundings)
                .ThenInclude(pf=> pf.CurrencyType)
                .Where(p => p.Id == Id).FirstOrDefault(); ;
            return data;
        }
    }
}
