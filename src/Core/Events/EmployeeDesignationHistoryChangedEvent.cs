using Core.Common;

namespace Core.Events
{
    public class EmployeeDesignationHistoryChangedEvent : DomainEvent
    {
        public EmployeeDesignationHistoryChangedEvent(string usrId)
        {
            ApplicationUserId = usrId;
        }

        public string ApplicationUserId { get; }
    }
}
