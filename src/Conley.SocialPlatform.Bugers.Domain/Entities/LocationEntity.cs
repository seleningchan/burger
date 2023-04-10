using System.Collections.Generic;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class LocationEntity
    {
        public List<double> Coordinates { get; set; }
        public string Type { get; set; }
    }
}
