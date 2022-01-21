using Application.Common.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Events;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Commands.CreateBossHistory
{
    class CreateBossHistoryCommandHandler : IRequestHandler<CreateBossHistoryCommand, List<string>>
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;

        public CreateBossHistoryCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(CreateBossHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeBossHistory bossHistItem = _mapper.Map<EmployeeBossHistory>(request);
            _context.EmployeeBossHistorys.Add(bossHistItem);
            bossHistItem.DomainEvents.Add(new EmployeeBossHistoryChangedEvent(bossHistItem.ApplicationUserId));
            _ = await _context.SaveChangesAsync(cancellationToken);
            return new List<string>();
        }
    }
}
