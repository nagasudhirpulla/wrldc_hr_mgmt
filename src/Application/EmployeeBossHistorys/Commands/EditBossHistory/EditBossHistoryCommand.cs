using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeBossHistorys.Commands.EditBossHistory
{
    public class EditBossHistoryCommand : IRequest<List<string>>, IMapFrom<EmployeeBossHistory>
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string BossUserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeBossHistory, EditBossHistoryCommand>();
        }
    }
}
