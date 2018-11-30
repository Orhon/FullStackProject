using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindproject2.Models
{
    public class PlansModel
    {
        public string planName { get; set; }
        public string planDescription { get; set; }
        public string planLocation { get; set; }
        public string category { get; set; }

        public DateTime date { get; set; }
    }
}
