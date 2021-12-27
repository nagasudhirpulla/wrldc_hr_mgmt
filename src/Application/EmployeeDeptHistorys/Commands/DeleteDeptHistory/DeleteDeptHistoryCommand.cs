﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.EmployeeDeptHistorys.Commands.DeleteDeptHistory
{
    public class DeleteDesignationHistoryCommand : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
