using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using KaznituLab.Models;
using KaznituLab.Models.WorkModels;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces;

namespace KaznituLab.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork Db;
        private readonly HrContext hrDb;
        public WorkService(IUnitOfWork db, HrContext hrdb)
        {
            Db = db;
            hrDb = hrdb;
        }
        public IEnumerable<WorkGetAllResponseModel> GetAll()
        {
            IEnumerable<WorkGetAllResponseModel> res;
            var data = Db.Works.IncludedGetAll();
            var hrEmp = hrDb.Employees.ToList();
            res = data.Select(d => new WorkGetAllResponseModel()
            {
                Id = d.Id,
                Title = d.Title,
                SourceTitle = d.SourceTitle,
                ReleaseYear = d.ReleaseYear,
                Doi = d.Doi,
                Issn = d.Issn,
                Essn = d.Essn,
                Isbn = d.Isbn,
                PublishedMonRK = d.PublishedMonRK,
                Author = hrEmp.Where(h => h.Id == d.AuthorId).Select(h => new WorkAuthorModel()
                {
                    Id = d.AuthorId,
                    Title = string.Concat(h.FirstName, " ", h.LastName, " ", h.MiddleName),
                    Iin = h.Iin
                }).FirstOrDefault(),
                WorkType = d.WorkType != null ? new DictionaryModel()
                {
                    Id = d.WorkType.Id,
                    Title = d.WorkType.Title
                } : null
            });
            return res;
        }

        public WorkGetResponseModel Get(int Id)
        {
            var res = new WorkGetResponseModel();
            var data = Db.Works.IncludedGet(Id);
            var hrEmp = hrDb.Employees.ToList();
            res = new WorkGetResponseModel()
            {
                Id = data.Id,
                Title = data.Title,
                SourceTitle = data.SourceTitle,
                ReleaseYear = data.ReleaseYear,
                Doi = data.Doi,
                Issn = data.Issn,
                Essn = data.Essn,
                Isbn = data.Isbn,
                PublishedMonRK = data.PublishedMonRK,
                Author = hrEmp.Where(h => h.Id == data.AuthorId).Select(h => new WorkAuthorModel()
                {
                    Id = data.AuthorId,
                    Title = string.Concat(h.FirstName, " ", h.LastName, " ", h.MiddleName),
                    Iin = h.Iin
                }).FirstOrDefault(),
                WorkType = data.WorkType != null ? new DictionaryModel()
                {
                    Id = data.WorkType.Id,
                    Title = data.WorkType.Title
                } : null,
                CoAuthors = data.WorkCoAuthors != null ? 
                    from e in data.WorkCoAuthors
                    join h in hrEmp on e.EmployeeId equals h.Id
                    select new WorkCoAuthorModel() { EmployeeId = h.Id, FullName = string.Concat(h.FirstName, " ", h.LastName, " ", h.MiddleName), FromSU = e.FromSU }
                    : null
            };
            return res;
        }
        public int Save(WorkRequestModel model)
        {
            var resData = model.GetWorkData();
            var workRes = new Work()
            {
                Id = resData.Id,
                Title = resData.Title,
                SourceTitle = resData.SourceTitle,
                WorkTypeId = resData.WorkType.Id,
                ReleaseYear = resData.ReleaseYear,
                Doi = resData.Doi,
                Issn = resData.Issn,
                Essn = resData.Essn,
                Isbn = resData.Isbn,
                PublishedMonRK = resData.PublishedMonRK,
                AuthorId = resData.Author.Id
            };
            Db.Works.InsertOrUpdate(workRes);
            Db.Complete();

            try
            {
                if (resData.CoAuthors != null && resData.CoAuthors.Count() > 0) 
                {
                    var coAuth = Db.Works.GetCoAuthorsByWorkId(workRes.Id);
                    var coAuthDel = coAuth.Where(ca => !resData.CoAuthors.Select(ca => ca.EmployeeId).Contains(ca.EmployeeId));
                    var coAuthIns = resData.CoAuthors.Where(ca => !coAuth.Select(a => a.EmployeeId).Contains(ca.EmployeeId));

                    Db.WorkCoAuthors.RemoveRange(coAuthDel);

                    var coAuthRes = coAuthIns.Select(ca => new WorkCoAuthor()
                    {
                        EmployeeId = ca.EmployeeId,
                        FromSU = ca.FromSU,
                        WorkId = workRes.Id
                    });

                    Db.WorkCoAuthors.InsertOrUpdateRange(coAuthRes);
                    Db.Complete();
                }
            }
            catch(Exception e)
            {
                Db.Dispose();
                throw new Exception(e.Message);
            }
            return workRes.Id;
        }
        public void Delete(int Id)
        {
            var data = Db.Works.Get(Id);
            data.Deleted = true;
            Db.Complete();
        }
    }
}
