using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ETB.Utilities;
using ETB.WebApi.DataAccess;
using ETB.WebApi.Middleware;
using ETB.WebApi.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        //private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
            //_logger = logger;
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.File("ETBlog-.log",rollingInterval:RollingInterval.Day,
            //    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            //.CreateLogger();

            //-- Not working- check later
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration.GetSection("Serilog"))
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console()
                .WriteTo.Debug()
                .Enrich.FromLogContext()
                //.MinimumLevel.Information()
                .WriteTo.File(env.ContentRootPath + "\\bin\\Log\\ETB.WebApi-.log", rollingInterval:RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss}|{SourceContext}|{Level:u4}|{Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettingsApi>(Configuration.GetSection("ApplicationSettingsApi"));
            services.AddTransient<DataProtector>();
            services.AddTransient<EncryptionDecryption>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddLogging(x =>
            //{

            //});
            services.AddDbContext<ETBContext>((option) =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("ETBContext"));
                //option.UseSqlServer(Configuration.GetConnectionString("ETBContext"), 
                //    (sqlOptions) =>
                //    {
                //        sqlOptions.UseNetTopologySuite();
                //    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ETB API", Version = "v1" });
            });
            services.AddHealthChecks();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();
            app.UseMiddleware<RequestAuditingMiddleWare>();
            app.UseHealthChecks("/ready");
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
