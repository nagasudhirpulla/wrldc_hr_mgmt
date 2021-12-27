using MediatR;
using System.Collections.Generic;

namespace Application.Users.Commands.UpdateUserLatestDesignation
{
    public class UpdateUserLatestDesignationCommand : IRequest<List<string>>
    {
        public string ApplicationUserId { get; set; }
    }
}
