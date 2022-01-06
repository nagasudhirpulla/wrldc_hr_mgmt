using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmployeeGradeHistorys.Commands.DeleteGradeHistory
{
    public class DeleteGradeHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
