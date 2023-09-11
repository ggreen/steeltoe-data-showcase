using steeltoe.data.showcase.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.Placeholder;
using Imani.Solutions.Core.API.Util;
using Microsoft.EntityFrameworkCore.Infrastructure;
using steeltoe.data.showcase.src.Migrations;

namespace lifescience_patient

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
;            
            //Run migration
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SampleContext>();
                
                new SampleContextSchemaMigration().Migrate(db.Database);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => 
                { 
                    webBuilder.UseStartup<Startup>(); 
                    webBuilder.AddPlaceholderResolver();
                    
                });
                
    }
}
