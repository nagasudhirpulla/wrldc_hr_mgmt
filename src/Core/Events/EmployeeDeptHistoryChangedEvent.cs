using Core.Common;

namespace Core.Events
{
    public class EmployeeDeptHistoryChangedEvent : DomainEvent
    {
        public EmployeeDeptHistoryChangedEvent(string usrId)
        {
            ApplicationUserId = usrId;
        }

        public string ApplicationUserId { get; }
    }
}
