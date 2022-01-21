using Core.Common;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EmployeeGradeHistory : AuditableEntity, IHasDomainEvent
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public DateTime FromDate { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
