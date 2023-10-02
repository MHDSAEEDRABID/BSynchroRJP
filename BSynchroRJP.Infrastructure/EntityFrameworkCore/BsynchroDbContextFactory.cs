using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BSynchroRJP.Infrastructure.EntityFrameworkCore
{
    public class BsynchroDbContextFactory : IDesignTimeDbContextFactory<BSynchroRJPDbContext>
    {
        public BSynchroRJPDbContext CreateDbContext(string[] args)
        {

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BSynchroRJPDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new BSynchroRJPDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../BSynchroRJP.Infrastructure/");
            var jsonFileName = "appsettings.json";
            if (env == "Development" && File.Exists(Path.Combine(jsonFilePath, $"appsettings.{env}.json")))
                jsonFileName = "appsettings.Development.json";

            var builder = new ConfigurationBuilder()
                .SetBasePath(jsonFilePath)
                .AddJsonFile(jsonFileName, optional: false);


            return builder.Build();
        }
    }
}
