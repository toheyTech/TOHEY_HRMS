using HRMS.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TOHEY.HRMS.Infrastructure
{
    public abstract class BaseContext : DbContext, IDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;
        protected BaseContext(DbContextOptions options,
            ICurrentUserService currentUserService,
            IDateTimeService dateTimeService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        protected BaseContext(DbContextOptions options)
            : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            entry.Entity.CreatedBy = _currentUserService.UserId;
                            entry.Entity.Created = _dateTimeService.Now;
                            break;
                        }
                    case EntityState.Modified:
                        {
                            entry.Entity.LastModifiedBy = _currentUserService.UserId;
                            entry.Entity.LastModified = _dateTimeService.Now;
                            break;
                        }

                    default:
                        throw new System.Exception("Unexpected Case");
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                x.State = EntityState.Detached;
                var keys = GetEntityKey(x.Entity);
                Set(x.Entity.GetType(), keys);
            });
        }

        public DbSet<T> Set<T>(T t, object[] keys) where T : class
        {
            return Set<T>();
        }

        public object[] GetEntityKey<T>(T entity) where T : class
        {
            var state = Entry(entity);
            var metadata = state.Metadata;
            var key = metadata.FindPrimaryKey();
            var props = key.Properties.ToArray();

            return props.Select(x => x.GetGetter().GetClrValue(entity)).ToArray();
        }

        IQueryable<T> IDbContext.Set<T>()
        {
            return Set<T>();
        }
    }
}

