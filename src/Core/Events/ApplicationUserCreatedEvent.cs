using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
