using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;

namespace KaznituLab.Repositories.Interfaces
{
    public interface IWorkRepository : IRepository<Work>
    {
        IEnumerable<Work> IncludedGetAll();
        Work IncludedGet(int Id);
        IEnumerable<WorkCoAuthor> GetCoAuthorsByWorkId(int Id);
    }
}
