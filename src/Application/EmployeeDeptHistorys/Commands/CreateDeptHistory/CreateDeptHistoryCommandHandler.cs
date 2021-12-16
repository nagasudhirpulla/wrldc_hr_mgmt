using Application.Common.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeDeptHistorys.Commands.CreateDeptHistory
{
    class CreateDeptHistoryCommandHandler : IRequestHandler<CreateDeptHistoryCommand, List<string>>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public CreateDeptHistoryCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(CreateDeptHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeDeptHistory deptHistItem = _mapper.Map<EmployeeDeptHistory>(request);
            _context.EmployeeDeptHistorys.Add(deptHistItem);
            deptHistItem.DomainEvents.Add(new EmployeeDeptHistoryChangedEvent(deptHistItem.ApplicationUserId));
            _ = await _context.SaveChangesAsync(cancellationToken);
            return new List<string>();
        }
    }
}
