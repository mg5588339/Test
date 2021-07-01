using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test.Application.Common.Interfaces;
using Test.Application.Users.Interfaces;
using Test.Application.Users.Models;
using Test.Domain.Entities.Users;

namespace Test.Application.Users.Implementations
{
    public class AccountService : IAccountService
    {
        #region constrctor

        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ISecurityService _securityService;
        private readonly ILogger<AccountService> _logger;
        
        public AccountService(IApplicationDbContext applicationDbContext, ISecurityService securityService,ILogger<AccountService> logger)
        {
            _applicationDbContext = applicationDbContext;
            _securityService = securityService;
            _logger = logger;
        }

        #endregion


        public async Task<LogInUserStatus> LoginUser(AccountLoginVm accountLoginVm)
        {
            try
            {
                User user = await _applicationDbContext.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserName == accountLoginVm.UserName);

                if (user == null)
                    return LogInUserStatus.IsNotFoundUser;

                bool IsTruePasssword = _securityService.VerifyHashedPassword(user.Password, accountLoginVm.Password);

                if (IsTruePasssword == false)
                    return LogInUserStatus.IsNotFoundUser;

                if (user.IsActive == false)
                    return LogInUserStatus.IsNotActiveUser;

                return LogInUserStatus.Success;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return LogInUserStatus.Error;
            }
        }

        public async Task<bool> IsExistsMobile(string mobile)
        {
            return await _applicationDbContext.Users.AsNoTracking().AnyAsync(u => u.Mobile == mobile);
        }

        
        public async Task<bool> IsValidMobile(string mobile)
        {
            var regex = @"(0|\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}";
            var match = Regex.Match(mobile, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return false;
            }

            return true;
        }

    }
}
