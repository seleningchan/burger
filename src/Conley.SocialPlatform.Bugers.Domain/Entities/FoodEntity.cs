using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class FoodEntity
    {
        public BsonObjectId _id { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public string FoodImagePath { get; set; }
    }
}
