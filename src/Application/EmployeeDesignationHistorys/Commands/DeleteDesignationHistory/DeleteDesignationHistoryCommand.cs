using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmployeeDesignationHistorys.Commands.DeleteDesignationHistory
{
    public class DeleteDesignationHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
