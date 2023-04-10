using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Contracts.Persistence;
using Conley.SocialPlatform.Bugers.Application.Contracts.Services;
using Conley.SocialPlatform.Bugers.Application.Dtos;
using Conley.SocialPlatform.Bugers.Infrastructure.Providers;

namespace Conley.SocialPlatform.Bugers.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public async Task<bool> CheckUserAsync(LoginParameter parameter)
        {
            var user = await _userRepository.GetUserAsync(parameter.UserName);
            if (user != null && SecurePasswordHasher.Hash(parameter.Password) == user.Password)
            {
                return true;
            }
            return false;
        }
    }
}
