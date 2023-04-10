using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conley.SocialPlatform.Bugers.Application.Dtos;

namespace Conley.SocialPlatform.Bugers.Application.Contracts.Services
{
    public interface IUserService
    {
        public Task<bool> CheckUserAsync(LoginParameter parameter);
    }
}
