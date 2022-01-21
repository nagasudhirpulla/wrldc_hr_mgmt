using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeDesignationHistorys.Commands.CreateDesignationHistory
{
    public  class CreateDesignationHistoryCommand :IRequest<List<string>>, IMapFrom<EmployeeDesignationHistory>
    {
        public string ApplicationUserId { get; set; }
        public int DesignationId { get; set; }
        public DateTime FromDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeDesignationHistory, CreateDesignationHistoryCommand>()
                .ReverseMap();
        }
    }
}
