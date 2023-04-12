using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Domain.Entities;
using MongoDB.Driver;

namespace Conley.SocialPlatform.Bugers.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _userCollection;

        public UserRepository(IMongoCollection<UserEntity> userCollection)
        {
            _userCollection = userCollection;
        }

        public Task AddEntityAsync(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> GetUserAsync(string userName)
        {
            using (var cursor = await _userCollection
               .Find(n => n.UserName == userName)
               .ToCursorAsync())
            {
                return await cursor.FirstOrDefaultAsync();
            }
        }
    }
}
