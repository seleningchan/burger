using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Application.Resources
{
    public class RatingResource
    {
        public int Taste { get; set; }
        public int Texture { get; set; }
        public int Visual { get; set; }
        public string RestaurantName { get; set; }
        public string FoodImagePath { get; set; }
        public string Comment { get; set; }
        public DateTime AddTime { get; set; }
    }
}
