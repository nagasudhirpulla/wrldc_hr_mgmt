using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmployeeBossHistorys.Commands.DeleteBossHistory
{
    public class DeleteBossHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
