using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoAPI.Entities;
using CityInfoAPI.Properties;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CityInfoAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            var connectionstring = Startup.Configuration["connectionStrings:cityInfoDBConnectionString"];
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionstring));

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoContext cityInfoContext)
        {
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            cityInfoContext.EnsureSeedDataForContext();

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<Entities.City, Models.CityDto>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointsOfInterestDto>();
                cfg.CreateMap<Models.PointsOfInterestForCreation, Entities.PointOfInterest>();
                cfg.CreateMap<Models.PointsOfInterestForUpdate, Entities.PointOfInterest>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointsOfInterestForUpdate>();
            });

            app.UseMvc();
        }
    }
}
