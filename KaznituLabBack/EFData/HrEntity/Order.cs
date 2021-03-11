using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class Order
    {
        public Order()
        {
            OrderEmployees = new HashSet<OrderEmployee>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? DateIssued { get; set; }
        public DateTime? DateActual { get; set; }
        public int? TypeId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatorId { get; set; }
        public bool? IsPublished { get; set; }
        public bool IsExecuted { get; set; }
        public int? MainTypeId { get; set; }

        public virtual SimpleDictionary Type { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployees { get; set; }
    }
}
