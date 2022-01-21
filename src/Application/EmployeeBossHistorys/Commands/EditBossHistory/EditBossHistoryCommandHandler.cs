using Application.Common.Interfaces;
using Core.Entities;
using Core.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EmployeeBossHistorys.Commands.EditBossHistory
{
    public class EditBossHistoryCommandHandler : IRequestHandler<EditBossHistoryCommand, List<string>>
    {
        private readonly ILogger<EditBossHistoryCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditBossHistoryCommandHandler(ILogger<EditBossHistoryCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditBossHistoryCommand request, CancellationToken cancellationToken)
        {
            EmployeeBossHistory bossHistItem = await _context.EmployeeBossHistorys
                                                .Where(bossHist => bossHist.Id == request.Id)
                                                .FirstOrDefaultAsync(cancellationToken);

            if (bossHistItem == null)
            {
                string errorMsg = $"Employee Boss History Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }

            // check if editing is required
            bool isEditRequired = false;
            if (bossHistItem.BossUserId != request.BossUserId || bossHistItem.FromDate != request.FromDate || bossHistItem.ToDate != request.ToDate)
            {
                isEditRequired = true;
            }
            if (isEditRequired)
            {
                bossHistItem.FromDate = request.FromDate;
                bossHistItem.ToDate = request.ToDate;
                bossHistItem.BossUserId = request.BossUserId;

                try
                {
                    // attach event
                    bossHistItem.DomainEvents.Add(new EmployeeBossHistoryChangedEvent(bossHistItem.ApplicationUserId));
                    // commit to database
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.EmployeeBossHistorys.Any(e => e.Id == request.Id))
                    {
                        return new List<string>() { $"Employee Boss History Id {request.Id} not present for editing" };
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return new List<string>();
        }
    }
}
