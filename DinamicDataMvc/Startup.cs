using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace DinamicDataMvc
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
            string ConnectionString = Configuration.GetConnectionString("ConnectionString");
            string DatabaseName = "MetadataProcessesDb";

            string nameFilteringResult = null;
            int versionFilteringResult = 0;

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<IGetProcessesMetadata, GetProcessesMetadataService>(s => new GetProcessesMetadataService(nameFilteringResult, versionFilteringResult));
            services.AddSingleton<IGetBranchById, GetBranchByIdService>(s => new GetBranchByIdService());
            services.AddSingleton<IConnectionManagement, ConnectionManagementService>(s => new ConnectionManagementService(ConnectionString, DatabaseName));

            services.AddSingleton<IGetStateById, GetStateByIdService>(s => new GetStateByIdService());
            services.AddSingleton<IGetProcessDetailsByName, GetProcessDetailsByNameService>(s => new GetProcessDetailsByNameService());

            services.AddSingleton<IMetadata, MetadataService>();
            
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new Info
                {
                    Title = "DinamicDataMvc",
                    Version = "v1",
                    Description = "Api Documentation"
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "HomePage" });

                //routes.MapRoute(
                //    name: "details",
                //    template: "{controller=Fake}/{action=ProcessDetails}/{name?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });
        }
    }
}
