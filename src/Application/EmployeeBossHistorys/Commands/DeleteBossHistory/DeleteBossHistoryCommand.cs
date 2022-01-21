using MediatR;
using System.Collections.Generic;

namespace Application.EmployeeBossHistorys.Commands.DeleteBossHistory
{
    public class DeleteBossHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
