using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Text;

namespace TOHEY.HRMS.Infrastructure
{
    public interface IDbContext
    {
        ChangeTracker ChangeTracker { get; }
        DbSet<T> Set<T>(T t, object[] keys) where T : class;
        IQueryable<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Rollback();
    }
}
