using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.API;
using Marketplace.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Marketplace
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostEnvironment environment,
            IConfiguration configuration)
        {
            Environment = environment;
            Configuration=configuration;
        }
        
        private IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddSingleton(new ClassifiedAdApplicationService());
            services.AddSingleton<IEntityStore, RavenDbEntityStore>();
            services.AddScoped<IHandleCommand<ClassifiedAds.V1.Create>>(c =>
                new RetryingCommandHandler<ClassifiedAds.V1.Create>(
                    new CreateClassifiedAdHandler(c.GetService<RavenDbEntityStore>())));
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "ClassifiedAds",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds v1"));
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            // });
        }
    }
}