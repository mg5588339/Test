using System.Threading.Tasks;
using Test.Application.Users.Models;

namespace Test.Application.Users.Interfaces
{
    public interface IAccountService
    {
        Task<LogInUserStatus> LoginUser(AccountLoginVm accountLoginVm);
        Task<bool> IsExistsMobile(string mobile);
        Task<bool> IsValidMobile(string mobile);
    }
}
