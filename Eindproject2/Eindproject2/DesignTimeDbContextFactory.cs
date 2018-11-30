using Eindproject2.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eindproject2
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Eindproject2APIContext>
    {
        Eindproject2APIContext IDesignTimeDbContextFactory<Eindproject2APIContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

            var builder = new DbContextOptionsBuilder<Eindproject2APIContext>();

            var connectionString = configuration.GetConnectionString("Eindproject2APIContext");

            builder.UseSqlServer(connectionString);

            return new Eindproject2APIContext(builder.Options);
        }

    }
}
