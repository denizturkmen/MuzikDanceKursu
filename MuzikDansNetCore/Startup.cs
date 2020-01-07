using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.Business.Concrete;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.DataAccessLayer.Concrete.EntityFrameWork;
using MuzikDansNetCore.Identity;
using MuzikDansNetCore.Middlewares;

namespace MuzikDansNetCore
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<ITeacherDal, EfCoreTeacherDal>();
            services.AddScoped<ITeacherService, TeacherManager>();
            services.AddScoped<IBranchDal, EfCoreBranchDal>();
            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<ILessonDal, EfCoreLessonDal>();
            services.AddScoped<ILessonService, LessonManager>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }


            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"branchEdit",
                    template:"/branch/update",
                    defaults: new { controller = "Branch", action = "BranchList" }
                    );

                routes.MapRoute(
                    name: "branchEdit",
                    template: "/branch/update/{id}",
                    defaults: new { controller = "Branch", action = "edit" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
        }
    }
}
