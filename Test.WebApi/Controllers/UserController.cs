using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Application.Common.Response;
using Test.Application.Users.Interfaces;
using Test.Application.Users.Models;
using Test.WebAPI.Controllers;

namespace Test.WebApi.Controllers
{
    public class UserController : BaseApiController
    {
        #region constrctor

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region AddUser

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]UserAddEditVm user)
        {
            if (await _userService.AddUserAsync(user))
                return JsonResponseStatus.Success(message: "عملیات با موفقیت انجام شد");
            else
                return JsonResponseStatus.Error(message: "دوباره تلاش کنید");
        }

        #endregion
    }
}
