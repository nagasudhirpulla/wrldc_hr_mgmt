using Core.Common;
using Core.ValueObjects;

namespace Core.Entities
{
    public class Grade : AuditableEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public PayScale PayScale { get; set; }
    }
}
