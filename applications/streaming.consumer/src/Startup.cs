using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Connector.PostgreSql.EFCore;
using Steeltoe.Connector.RabbitMQ;
using Steeltoe.Management.Endpoint;
using Steeltoe.Stream.Extensions;
using streaming.consumer.Consumer;
using System;
using steeltoe.data.Showcase.Repository;

namespace steeltoe.streaming.consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountDbContext>(options => options.UseNpgsql(Configuration));
            services.AddRabbitMQConnection(Configuration);
            services.AddScoped<IAccountRepository,AccountDataRepository>();
            services.AddAllActuators(Configuration);
            services.ActivateActuatorEndpoints();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "steeltoe.streaming.consumer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "steeltoe.streaming.consumer"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
