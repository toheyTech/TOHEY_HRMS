using System.Threading.Tasks;

namespace TOHEY.HRMS.Application
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(int id);
    }
}
