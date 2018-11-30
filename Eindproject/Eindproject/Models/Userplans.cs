using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eindproject.Models
{
    public class Userplans
    {
        public int PlanID { get; set; }
        public int UserID { get; set; }

        public virtual Plans Plans { get; set; }
        public virtual Users Users { get; set; }
    }
}
