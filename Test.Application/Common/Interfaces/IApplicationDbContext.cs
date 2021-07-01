using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;
using Test.Domain.Entities.Root;
using Test.Domain.Entities.Users;

namespace Test.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        #region User

        DbSet<User> Users { get; set; }
        DbSet<Domain.Entities.Weathers.Weather> Weathers { get; set; }

        #endregion


        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken, bool modified = true);
        int SaveChanges(bool modified = true);
    }
}
