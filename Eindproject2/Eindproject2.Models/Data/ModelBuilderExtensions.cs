using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eindproject2.Models.Data
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var plans = new[]
            {
                new Plans {ID=1, planName="Concert", category="Concert", planDescription="Concert van U2 in Antwerpen", planLocation="Antwerpen", date=new DateTime(2018, 12, 18)}
            };

            modelBuilder.Entity<Plans>().HasData(plans);
        }
    }
}
