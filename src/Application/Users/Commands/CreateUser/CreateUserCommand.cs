using AutoMapper;
using Core.Entities;
using Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
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
        public int OfficeId { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public string BossUserId { get; set; }
        public int GradeId { get; set; }
        public bool IsActive { get; set; } = true;
        public string FatherName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime DateofJoining { get; set; }
        public int Gender { get; set; }
        public int EthnicOrigin { get; set; }
        public string DomicileState { get; set; }
        public string Religion { get; set; }
        public int SpeciallyAbled { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string EmailId { get; set; }
        public string UAN { get; set; }
        public string PRAN { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, CreateUserCommand>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.IsTwoFactorEnabled, opt => opt.MapFrom(s => s.TwoFactorEnabled))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender.Value))
                .ForMember(d => d.EthnicOrigin, opt => opt.MapFrom(s => s.EthnicOrigin.Value))
                .ForMember(d => d.SpeciallyAbled, opt => opt.MapFrom(s => s.SpeciallyAbled.Value))
                .ReverseMap()
                .ForMember(s => s.Gender, opt => opt.MapFrom(src => GenderEnum.FromValue(src.Gender)))
                .ForMember(s => s.EthnicOrigin, opt => opt.MapFrom(src => EthnicOriginEnum.FromValue(src.EthnicOrigin)))
                .ForMember(s => s.SpeciallyAbled, opt => opt.MapFrom(src => SpeciallyAbledEnum.FromValue(src.SpeciallyAbled)));
        }
    }
}
