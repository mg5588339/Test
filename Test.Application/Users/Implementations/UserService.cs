using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Common.Interfaces;
using Test.Application.Users.Interfaces;
using Test.Application.Users.Models;
using Test.Domain.Entities.Users;

namespace Getwork.Application.Users.Implementations
{
    public class UserService : IUserService
    {
        #region constrctor

        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        public UserService(IApplicationDbContext applicationDb,IMapper mapper,ILogger<UserService> logger,ISecurityService securityService)
        {
            _context = applicationDb;
            _mapper = mapper;
            _logger = logger;
            _securityService = securityService;
        }

        #endregion

        public async Task<UserIndexVm> GetUserByUserName(string userName)
        {
            return await _context.Users.Where(u => u.UserName == userName).ProjectTo<UserIndexVm>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<bool> AddUserAsync(UserAddEditVm userAddEdit)
        {
            try
            {
                var hashPassword = _securityService.HashPassword(userAddEdit.Password);
                var user = _mapper.Map<User>(userAddEdit);
                user.Password = hashPassword;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(new System.Threading.CancellationToken());
               
                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
