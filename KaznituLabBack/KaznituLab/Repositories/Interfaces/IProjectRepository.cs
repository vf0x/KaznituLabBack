using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;

namespace KaznituLab.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> IncludedGetAll();
        Project IncludedGet(int Id);
    }
}
