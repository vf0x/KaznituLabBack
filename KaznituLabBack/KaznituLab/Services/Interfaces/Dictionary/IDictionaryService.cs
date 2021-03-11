using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;
using EFData.HrEntity;
using KaznituLab.Models;
using KaznituLab.Models.Types;

namespace KaznituLab.Services.Interfaces.Dictionary
{
    public interface IDictionaryService
    {
        List<DictionaryModel> GetDictionary(DictionaryType type);

    }
}
