using MediatR;
using System.Collections.Generic;

namespace Application.Users.Commands.UpdateUserLatestBoss
{
    public class UpdateUserLatestBossCommand : IRequest<List<string>>
    {
        public string ApplicationUserId { get; set; }
    }
}
