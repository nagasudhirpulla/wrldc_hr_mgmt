using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmployeeDesignationHistory : AuditableEntity, IHasDomainEvent
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public DateTime FromDate { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
