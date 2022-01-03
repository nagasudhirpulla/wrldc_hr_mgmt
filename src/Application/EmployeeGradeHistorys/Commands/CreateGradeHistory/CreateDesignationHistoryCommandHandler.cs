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

namespace Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory
{
    class CreateDesignationHistoryCommandHandler : IRequestHandler<CreateDesignationHistoryCommand, List<string>>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public CreateDesignationHistoryCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(CreateDesignationHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeDesignationHistory designationHistItem = _mapper.Map<EmployeeDesignationHistory>(request);
            _context.EmployeeDesignationHistorys.Add(designationHistItem);
            designationHistItem.DomainEvents.Add(new EmployeeDesignationHistoryChangedEvent(designationHistItem.ApplicationUserId));
            _ = await _context.SaveChangesAsync(cancellationToken);
            return new List<string>();
        }
    }
}
