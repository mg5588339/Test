using System.Threading.Tasks;
using Test.Application.Users.Models;

namespace Test.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserIndexVm> GetUserByUserName(string userName);
        Task<bool> AddUserAsync(UserAddEditVm userAddEdit);
    }
}
