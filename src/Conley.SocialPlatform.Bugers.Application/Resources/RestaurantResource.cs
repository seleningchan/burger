using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Application.Resources
{
    public class RestaurantResource
    {
        public DateTime OpenTime { get; set; }
        public DateTime EndTime { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }
    }
}
