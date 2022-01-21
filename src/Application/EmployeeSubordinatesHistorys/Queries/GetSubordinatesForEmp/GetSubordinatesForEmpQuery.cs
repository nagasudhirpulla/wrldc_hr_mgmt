﻿
using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Application.EmployeeSubordinatesHistorys.Queries.GetSubordinatesForEmp
{
    public class GetSubordinatesForEmpQuery : IRequest<List<EmployeeBossHistory>>
    {
        public string ApplicationUserId { get; set; }
        public class GetSubordinatesForEmpQueryHandler : IRequestHandler<GetSubordinatesForEmpQuery, List<EmployeeBossHistory>>
        {
            private readonly IAppDbContext _context;

            public GetSubordinatesForEmpQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<EmployeeBossHistory>> Handle(GetSubordinatesForEmpQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeBossHistory> res = await _context.EmployeeBossHistorys
                                                    .Where(e => e.BossUserId == request.ApplicationUserId)
                                                    .Include(e => e.ApplicationUser)
                                                    .Include(e => e.BossUser)
                                                    .ToListAsync(cancellationToken: cancellationToken);
                return res;
            }
        }
    }
}

