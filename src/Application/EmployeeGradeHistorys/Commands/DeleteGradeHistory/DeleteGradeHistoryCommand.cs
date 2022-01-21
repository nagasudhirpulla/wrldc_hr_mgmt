using MediatR;
using System.Collections.Generic;

namespace Application.EmployeeGradeHistorys.Commands.DeleteGradeHistory
{
    public class DeleteGradeHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
