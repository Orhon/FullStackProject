using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eindproject2.Models
{
    public class Plans
    {
        [Key] public int ID { get; set; }

        [Required]
        public string planName { get; set; }
        public string planDescription { get; set; }
        public string planLocation { get; set; }
        public string category { get; set; }

        public DateTime date { get; set; }

        public ICollection<Userplans> Userplans { get; set; }
    }
}
