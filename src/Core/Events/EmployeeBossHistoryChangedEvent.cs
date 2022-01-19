using Core.Common;

namespace Core.Events
{
    public class EmployeeBossHistoryChangedEvent : DomainEvent
    {
        public EmployeeBossHistoryChangedEvent(string usrId)
        {
            ApplicationUserId = usrId;
        }

        public string ApplicationUserId { get; }
    }
}
