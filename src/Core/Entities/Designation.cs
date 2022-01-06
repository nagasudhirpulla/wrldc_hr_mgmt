using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
