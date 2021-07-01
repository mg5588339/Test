using AutoMapper;
using System;
using Test.Application.Common.Mappings;
using Test.Domain.Entities.Users;

namespace Test.Application.Users.Models
{
    public class UserIndexVm : IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserIndexVm>();
        }
    }
}
