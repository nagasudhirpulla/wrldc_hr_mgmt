using MediatR;
using System.Collections.Generic;

namespace Application.EmployeeDesignationHistorys.Commands.DeleteDesignationHistory
{
    public class DeleteDesignationHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
