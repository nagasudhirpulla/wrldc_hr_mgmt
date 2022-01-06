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

namespace Application.EmployeeGradeHistorys.Commands.CreateGradeHistory
{
    class CreateGradeHistoryCommandHandler : IRequestHandler<CreateGradeHistoryCommand, List<string>>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public CreateGradeHistoryCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(CreateGradeHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeGradeHistory gradeHistItem = _mapper.Map<EmployeeGradeHistory>(request);
            _context.EmployeeGradeHistorys.Add(gradeHistItem);
            gradeHistItem.DomainEvents.Add(new EmployeeGradeHistoryChangedEvent(gradeHistItem.ApplicationUserId));
            _ = await _context.SaveChangesAsync(cancellationToken);
            return new List<string>();
        }
    }
}
