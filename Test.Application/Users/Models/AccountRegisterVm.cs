using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Common.Mappings;
using Test.Domain.Entities.Users;

namespace Test.Application.Users.Models
{
    public class AccountRegisterVm : IMapFrom<User>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, AccountLoginVm>();
        }
    }
}
