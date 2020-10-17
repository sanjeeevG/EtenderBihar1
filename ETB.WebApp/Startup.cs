using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETB.WebApp.Services;
using ETB.WebApp.Utilities;
using ETB.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using ETB.Utilities.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ETB.Utilities.SMS;
using Microsoft.AspNetCore.Identity;


namespace ETB.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            //Configuration = configuration;
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.Console()
                .WriteTo.Debug()
                .Enrich.FromLogContext()
                //.MinimumLevel.Information()
                .WriteTo.File(env.ContentRootPath + "\\bin\\Log\\ETB.WebApi-.log", rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss}|{SourceContext}|{Level:u4}|{Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true; // consent required
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddMvc().AddSessionStateTempDataProvider();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddSessionStateTempDataProvider();

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                options.HttpsPort = 443;
            });

            services.AddSession(s =>
            {
                s.IdleTimeout = TimeSpan.FromMinutes(20);
                //s.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(option =>
                    {
                        option.LoginPath = new PathString("/UserInfo/Login");
                        option.LogoutPath = new PathString("/UserInfo/Logout");
                        option.AccessDeniedPath = new PathString("/UserInfo/AccessDenied");
                        option.Cookie.SameSite = SameSiteMode.Strict;
                        option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    });


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDataProtection();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<SMSSettings>(Configuration.GetSection("SMSSettings"));
            services.Configure<BankDetails>(Configuration.GetSection("BankDetails"));
            services.Configure<ContactDetails>(Configuration.GetSection("ContactDetails"));
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddSingleton<EncryptionDecryption>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<ISMSSender, SMSSender>();
            services.AddSingleton<EmailSenderService>();
            services.AddSingleton<SMSSenderService>();
            services.AddTransient<DataProtector>();
            services.AddTransient<StateService>();
            services.AddTransient<DistrictService>();
            services.AddTransient<DepartmentService>();
            services.AddTransient<ServiceService>();
            services.AddTransient<DivisionService>();
            services.AddTransient<TenderService>();
            services.AddTransient<UserInfoService>();
            services.AddTransient<UserSubscriptionService>();
            services.AddSingleton<ExtendedContactService>();
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Configuration.GetSection("ApplicationSettings:NitFilePath").Value)));

            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var dtf = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd-MM-yyyy",
                LongDatePattern = "dd-MM-yyyy HH:mm",
                ShortTimePattern = "HH:mm",
                LongTimePattern = "HH:mm"
            };

            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-IN") { DateTimeFormat = dtf },
                new CultureInfo("en") { DateTimeFormat = dtf }
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-IN"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

            
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Tenders}/{action=Index}/{id?}");
            });
        }
    }
}
