using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Domain.Entities;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        public Task AddEntityAsync(FoodEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
