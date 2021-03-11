using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class Department
    {
        public Department()
        {
            InverseParent = new HashSet<Department>();
            OrderEmployees = new HashSet<OrderEmployee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public string TitleKaz { get; set; }
        public string TitleEng { get; set; }
        public string ShortTitleRus { get; set; }
        public string ShortTitleKaz { get; set; }
        public string ShortTitleEng { get; set; }
        public int? TypeId { get; set; }
        public bool Deleted { get; set; }

        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> InverseParent { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployees { get; set; }
    }
}
