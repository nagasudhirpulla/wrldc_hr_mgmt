using Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Designation : AuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }

    }
}
