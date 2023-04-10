using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conley.SocialPlatform.Bugers.Domain.Entities
{
    public class CityEntity
    {
        public int _Id { get; set; }
        public int Id { get; set; }
        public LocationEntity Location { get; set; }
        public string CityName { get; set; }
        public string Abbr { get; set; }
        public string AreaCode { get; set; }
    }
}
