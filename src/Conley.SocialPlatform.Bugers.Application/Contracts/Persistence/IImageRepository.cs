using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Persistence
{
    public interface IImageRepository : IGenericRepository<ImageEntity>
    {
      
    }
}
