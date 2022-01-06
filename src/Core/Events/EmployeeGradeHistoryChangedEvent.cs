using Core.Common;

namespace Core.Events
{
    public class EmployeeGradeHistoryChangedEvent : DomainEvent
    {
        public EmployeeGradeHistoryChangedEvent(string usrId)
        {
            ApplicationUserId = usrId;
        }

        public string ApplicationUserId { get; }
    }
}
