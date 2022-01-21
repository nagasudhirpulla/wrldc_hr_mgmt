using Core.Common;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EmployeeDeptHistory : AuditableEntity, IHasDomainEvent
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime FromDate { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
