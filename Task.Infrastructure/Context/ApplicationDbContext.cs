

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Test.Application.Common.Interfaces;
using Test.Domain.Entities.Root;
using Test.Domain.Entities.Users;

namespace Test.Infrastructure.Persistence
{
    //Add-Migration InitialDatabase -o "Persistence/Migrations"
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }


        #region User

        public DbSet<User> Users { get; set; }

        public DbSet<Domain.Entities.Weathers.Weather> Weathers { get; set; }

        #endregion

        public IDbContextTransaction BeginTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this.Database.BeginTransactionAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken(),
            bool modified = true)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }


        public new int SaveChanges(bool modified = true)
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}