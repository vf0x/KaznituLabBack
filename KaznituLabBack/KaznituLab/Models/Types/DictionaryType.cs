using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KaznituLab.Models.Types
{
    public enum DictionaryType
    {
        Departments = 0,
        Positions = 1,
        EquipmentStatuses = 10,
        LaboratoryStatuses = 11,
        ProjectStatuses = 12,
        BibliographicDbTypes = 13,
        CurrencyTypes = 14,
        FinancingTypes = 15,
        WorkTypes = 16
    }
}
