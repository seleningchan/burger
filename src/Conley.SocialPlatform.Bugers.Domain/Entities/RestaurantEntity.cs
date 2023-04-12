using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class RestaurantEntity
    {
        
        public BsonObjectId _id { get; set; }
        //public int Id { get; set; }
        public int RestaurantId { get; set; }
        public bool ContainBurger { get; set; }
        public BsonDateTime OpenTime { get; set; }
        public BsonDateTime EndTime { get; set; }
        public LocationEntity Location { get; set; }
        public string RestaurantName { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
    }
}
