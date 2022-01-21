using MediatR;
using System.Collections.Generic;

namespace Application.EmployeeDeptHistorys.Commands.DeleteDeptHistory
{
    public class DeleteDeptHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
