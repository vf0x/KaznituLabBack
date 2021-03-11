using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFData.Entity
{
    public class CurrencyType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Deleted { get; set; }
    }
}
