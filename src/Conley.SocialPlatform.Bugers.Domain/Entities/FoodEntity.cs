using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class FoodEntity
    {
        public string _Id { get; set; }
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public string FoodImagePath { get; set; }
    }
}
