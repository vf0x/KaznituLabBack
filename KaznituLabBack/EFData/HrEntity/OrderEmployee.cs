using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class OrderEmployee
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public int? TariffRateId { get; set; }
        public int? HiringConditionId { get; set; }
        public int? CancelingReasonId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public byte? Notificated { get; set; }
        public int? PositionIdOld { get; set; }
        public int? DepartmentIdOld { get; set; }
        public string EmploymentOrderId { get; set; }
        public string NewFirstName { get; set; }
        public string NewMiddleName { get; set; }
        public string NewLastName { get; set; }
        public string NewFirstNameTranslit { get; set; }
        public string NewMiddleNameTranslit { get; set; }
        public string NewLastNameTranslit { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsExecuted { get; set; }
        public bool? IsMainPosition { get; set; }
        public bool? TempMainPosition { get; set; }
        public string Comment { get; set; }

        public virtual SimpleDictionary CancelingReason { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SimpleDictionary HiringCondition { get; set; }
        public virtual Order Order { get; set; }
        public virtual Position Position { get; set; }
        public virtual SimpleDictionary TariffRate { get; set; }
    }
}
