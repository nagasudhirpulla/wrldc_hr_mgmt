using Core.Common;
using Core.Entities;

namespace Core.Events
{
    public class ApplicationUserCreatedEvent : DomainEvent
    {
        public ApplicationUserCreatedEvent(ApplicationUser appUser)
        {
            AppUser = appUser;
        }

        public ApplicationUser AppUser { get; }
    }
}
