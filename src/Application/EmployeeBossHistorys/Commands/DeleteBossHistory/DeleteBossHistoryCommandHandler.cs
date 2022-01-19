using Application.Common.Interfaces;
using Core.Entities;
using Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Commands.DeleteBossHistory
{
    public class DeleteBossHistoryCommandHandler : IRequestHandler<DeleteBossHistoryCommand, List<string>>
    {
        private readonly IAppDbContext _context;

        public DeleteBossHistoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(DeleteBossHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeBossHistory bossHistItem = await _context.EmployeeBossHistorys.FindAsync(request.Id);

            if (bossHistItem == null)
            {
                string errorMsg = $"Employee Boss History Id {request.Id} not present for deleting";
                return new List<string>() { errorMsg };
            }

            _context.EmployeeBossHistorys.Remove(bossHistItem);

            // attach event
            bossHistItem.DomainEvents.Add(new EmployeeBossHistoryChangedEvent(bossHistItem.ApplicationUserId));
            // commit to database
            _ = await _context.SaveChangesAsync(cancellationToken);

            return new List<string>();
        }
    }
}
