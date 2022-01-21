using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeBossHistorys.Commands.CreateBossHistory
{
    public  class CreateBossHistoryCommand :IRequest<List<string>>, IMapFrom<EmployeeBossHistory>
    {
        public string ApplicationUserId { get; set; }
        public string BossUserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeBossHistory, CreateBossHistoryCommand>()
                .ReverseMap();
        }
    }
}
