
using MovieDatabase.Common.Mappings;

namespace MovieDatabase.WebApi
{
    using System;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Db;

    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public  IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            var connection = Configuration["ConnectionString:MovieDatabaseDb"];
            services.AddDbContext<MovieDatabaseContext>
                (options => options.UseSqlServer(connection));

            ConfigureAutofac(services);

            return new AutofacServiceProvider(this.ApplicationContainer);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperInitializer.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
