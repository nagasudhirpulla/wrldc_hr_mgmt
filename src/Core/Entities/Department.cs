using Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Department : AuditableEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
