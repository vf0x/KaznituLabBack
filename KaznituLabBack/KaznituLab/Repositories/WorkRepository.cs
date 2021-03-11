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
    public class WorkRepository : Repository<Work>, IWorkRepository
    {
        public WorkRepository(KaznituLabContext context) : base(context)
        {

        }
        public IEnumerable<Work> IncludedGetAll()
        {
            var data =_context.Works
                .Include(w => w.WorkType)
                .Where(w => w.Deleted == false)
                .ToList();
            return data;
        }
        public Work IncludedGet(int Id)
        {
            var data = _context.Works
                .Include(w => w.WorkType)
                .Include(w=> w.WorkCoAuthors)
                .Where(w => w.Deleted == false && w.Id == Id)
                .FirstOrDefault();
            return data;
        }
        public IEnumerable<WorkCoAuthor> GetCoAuthorsByWorkId(int Id)
        {
            var data = _context.WorkCoAuthors.Where(ca => ca.WorkId == Id).ToList();
            return data;
        }
    }
}
