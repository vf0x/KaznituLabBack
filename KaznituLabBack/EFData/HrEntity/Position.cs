using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class Position
    {
        public Position()
        {
            OrderEmployees = new HashSet<OrderEmployee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleKaz { get; set; }
        public string TitleEng { get; set; }
        public string DescriptionRus { get; set; }
        public string DescriptionKaz { get; set; }
        public string DescriptionEng { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<OrderEmployee> OrderEmployees { get; set; }
    }
}
