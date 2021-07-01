using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Common.Response;
using Test.Application.Users.Interfaces;
using Test.Application.Users.Models;

namespace Test.WebAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        #region constrctor

        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        #endregion


        #region login

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginVm accountLoginVm)
        {
            if (accountLoginVm.UserName == null)
                return JsonResponseStatus.Error(message: "نام کاربری وارد نشده است ");

            if (accountLoginVm.Password == null)
                return JsonResponseStatus.Error(message: "کلمع عبور وارد نشده است ");

            var res = await _accountService.LoginUser(accountLoginVm);
            switch (res)
            {
                case LogInUserStatus.IsNotFoundUser:
                    return JsonResponseStatus.Error(message: "کاربری یافت نشد");

                case LogInUserStatus.IsNotActiveUser:
                    return JsonResponseStatus.Error(message: "حساب کاربری یافت نشد");

                case LogInUserStatus.Error:
                    return JsonResponseStatus.Error(message: "خطای داخلی رخ داد ");

                case LogInUserStatus.Success:
                    var user = await _userService.GetUserByUserName(accountLoginVm.UserName);


                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OnlineConsolation"));
                    var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
                    var tokenOption = new JwtSecurityToken(
                        issuer: "https://localhost:44304",
                        claims: new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                        },
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: signinCredential
                     );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                    return JsonResponseStatus.SuccessLogin(token: tokenString);
            }

            return JsonResponseStatus.Error(message: "خطای داخلی رخ داد ");
        }

        #endregion
    }
}
