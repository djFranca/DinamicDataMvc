using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Services.Database;
using DinamicDataMvc.Services.Metadata;
using DinamicDataMvc.Services.Fields;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using DinamicDataMvc.Utils;
using DinamicDataMvc.Services.Pagination;
using DinamicDataMvc.Services.Validation;
using DinamicDataMvc.Services.Config;
using DinamicDataMvc.Services.Properties;
using DinamicDataMvc.Services.Data;

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
            string versionFilteringResult = null;

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Registo de serviços - A interface sabe instanciar a classe correspondente ao serviço que engloba os micro serviços;
            services.AddSingleton<IMetadataService, MetadataService>(s => new MetadataService(nameFilteringResult, versionFilteringResult));
            services.AddSingleton<IBranchService, BranchService>(s => new BranchService());
            services.AddSingleton<IConnectionManagementService, ConnectionManagementService>(s => new ConnectionManagementService(ConnectionString, DatabaseName));
            services.AddSingleton<IStateService, StateService>(s => new StateService());
            services.AddSingleton<IFieldService, FieldService>(s => new FieldService());
            services.AddSingleton<IPropertyService, PropertyService>(s => new PropertyService());
            services.AddSingleton<IKeyGenerates, KeyGenerates>(s => new KeyGenerates(8)); //8 is the number of bits to use ina a hexdecimal generated key
            services.AddSingleton<IPaginationService, PaginationService>(s => new PaginationService(4));
            services.AddSingleton<IValidationService, ValidationService>(s => new ValidationService());
            services.AddSingleton<IMessage, Message>(s => new Message());
            services.AddSingleton<IProcessHistory, ProcessHistory>(s => new ProcessHistory());
            services.AddSingleton<IDataService, DataService>(s => new DataService());
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
                //TODO: Flata criar uma página para erro ou Not Found
                string error_page = "";
                app.UseExceptionHandler(error_page);
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "HomePage" });
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
