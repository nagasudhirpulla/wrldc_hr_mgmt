using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using static Application.Common.Mappings.MappingProfile;

namespace Application.EmployeeGradeHistorys.Commands.CreateGradeHistory
{
    public  class CreateGradeHistoryCommand :IRequest<List<string>>, IMapFrom<EmployeeGradeHistory>
    {
        public string ApplicationUserId { get; set; }
        public int GradeId { get; set; }
        public DateTime FromDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EmployeeGradeHistory, CreateGradeHistoryCommand>()
                .ReverseMap();
        }
    }
}
