using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using QLGVT.Application.Implementation;
using QLGVT.Application.Interfaces;
using QLGVT.Authorization;
using QLGVT.Data;
using QLGVT.Data.EF;
using QLGVT.Data.EF.Repositories;
using QLGVT.Data.Entities;
using QLGVT.Data.IRepositories;
using QLGVT.Helpers;
using QLGVT.Infrastructure.Interfaces;
using QLGVT.Models;
using QLGVT.Services;

namespace QLGVT
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("QLGVT.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
           
            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddAutoMapper();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<DbInitializer>();
            
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));

            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();
            
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //services.AddMvc();

            //Repositories
            services.AddTransient<IFunctionRepository, FunctionRepository>();

            services.AddTransient<IPermissionRepository, PermissionRepository>();

            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ISystemConfigRepository, SystemConfigRepository>();

            services.AddTransient<IFooterRepository, FooterRepository>();



            services.AddTransient<IDonviVantaiReposiory, DonviVantaiReposiory>();

            services.AddTransient<IBenxeRepository, BenxeRepository>();

            services.AddTransient<ITuyenRepository, TuyenRepository>();

            //Serrvices
            services.AddTransient<IFunctionService, FunctionService>();

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

            services.AddTransient<ICommonService, CommonService>();


            services.AddTransient<IDonviVantaiService, DonviVantaiService>();

            services.AddTransient<IBenxeService, BenxeService>();

            services.AddTransient<ITuyenService, TuyenService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/MCST-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
