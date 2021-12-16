using Application.Users.Queries.GetAppUsers;
using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using static Application.Common.Mappings.MappingProfile;

namespace Application.Users.Commands.UpdateUserLatestDept
{
    public class UpdateUserLatestDeptCommand : IRequest<List<string>>, IMapFrom<UserDTO>
    {
        public int DepartmentId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UpdateUserLatestDeptCommand>()
                .ForMember(d => d.DepartmentId, opt => opt.MapFrom(s => s.DepartmentId));
        }
    }
}
