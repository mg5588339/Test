using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Common;

namespace Test.Domain.Entities.Weathers
{
   public class Weather : BaseEntity<long>
    {
        public string Country { get; set; }
        public string CityName { get; set; }
        public double Tmp { get; set; }
        public int TimeZone { get; set; }
    }
}
