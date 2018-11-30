using System;
using System.Collections.Generic;
using System.Text;

namespace Eindproject2.Models
{
    public class Userinfo
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Userplans> Userplans { get; set; }
    }
}
