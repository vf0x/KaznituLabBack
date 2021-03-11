using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Context;
using EFData.Entity;
using EFData.HrEntity;
using KaznituLab.Models;
using KaznituLab.Models.Types;
using KaznituLab.Repositories.Interfaces.UnitOfWork;
using KaznituLab.Services.Interfaces.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace KaznituLab.Services.DictionaryService
{
    public class DictionaryService : IDictionaryService
    {
        private readonly HrContext hrDb;
        private readonly KaznituLabContext Db;
        public DictionaryService(HrContext hrdb, KaznituLabContext db)
        {
            hrDb = hrdb;
            Db = db;
        }
        public List<DictionaryModel> GetDictionary(DictionaryType type)
        {
            if(type.GetHashCode() < 10)
            {
                string query = $"SELECT Id, Title FROM {type.ToString()}  WHERE Deleted = 0";
                var data = hrDb.Dictionaries.FromSqlRaw(query);
                var res = data.Select(d => new DictionaryModel()
                {
                    Id = d.Id,
                    Title = d.Title
                }).ToList();
                return res;
            }
            else
            {
                string query = $"SELECT Id, Title FROM {type.ToString()}  WHERE Deleted = 0";
                var data =  Db.Dictionaries.FromSqlRaw(query).ToList();
                var res = data.Select(d => new DictionaryModel()
                {
                    Id = d.Id,
                    Title = d.Title
                }).ToList();
                return res;
            }
            
        }
    }
}
