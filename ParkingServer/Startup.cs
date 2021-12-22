using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParkingServer.Repository;
using ParkingServer.Repository.Services;
using ParkingServer.Repository.Services.Interfaces;
using ParkingServer.Repository.UnitOfWorkFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServer
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
            services.AddControllers();

            string connectionString = Configuration.GetConnectionString("ConnectionStringLocalhost2");
            services.AddDbContext<RepositoryContext>(options => { options.UseSqlServer(connectionString); });

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPriceRangeService, PriceRangeService>();
            services.AddTransient<IVehicleTypeService, VehicleTypeService>();
            services.AddTransient<IParkingDataService, ParkingDataService>();
            services.AddTransient<IRegisteredVehicleService, RegisteredVehicleService>();
            services.AddTransient<IParkingStatusService, ParkingStatusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
