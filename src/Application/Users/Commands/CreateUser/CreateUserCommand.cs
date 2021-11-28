using AutoMapper;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Application.Common.Mappings.MappingProfile;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<IdentityResult>, IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserRole { get; set; } = SecurityConstants.EmployeeRoleString;
        public bool IsTwoFactorEnabled { get; set; }
        public string OfficeId { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; } = true;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, CreateUserCommand>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.IsTwoFactorEnabled, opt => opt.MapFrom(s => s.TwoFactorEnabled))
                .ReverseMap();
        }
    }
}
