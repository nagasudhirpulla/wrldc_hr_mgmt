using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmployeeDeptHistorys.Commands.DeleteDeptHistory
{
    public class DeleteDeptHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
