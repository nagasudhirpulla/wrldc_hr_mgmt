using Core.Common;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EmployeeBossHistory : AuditableEntity, IHasDomainEvent
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string BossUserId { get; set; }
        public ApplicationUser BossUser { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
