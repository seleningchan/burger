using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class CityEntity
    {
        public BsonObjectId _id { get; set; }
        public int CityId { get; set; }
        public LocationEntity Location { get; set; }
        public string CityName { get; set; }
        public string Abbr { get; set; }
        public string AreaCode { get; set; }
    }
}
