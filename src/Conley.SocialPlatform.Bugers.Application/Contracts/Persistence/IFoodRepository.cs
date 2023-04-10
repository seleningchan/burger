using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Persistence
{
    public interface IFoodRepository : IGenericRepository<FoodEntity>
    {
    }
}
