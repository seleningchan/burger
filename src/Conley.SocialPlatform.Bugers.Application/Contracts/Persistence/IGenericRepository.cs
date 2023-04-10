using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddEntityAsync(T entity);
    }
}
