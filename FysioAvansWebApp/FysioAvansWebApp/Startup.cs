using FysioAvansWebApp.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Models.Repo;

namespace FysioAvansWebApp
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
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddHttpClient<IDiagnosisRepo, SQLDiagnosisRepository>(c =>
            {
                c.BaseAddress = new Uri("https://physiotherapistwebservice.azurewebsites.net/api/");
            });

            services.AddHttpClient<IVTreatmentRepo, SQLVTreatmentRepository>(c =>
            {
                c.BaseAddress = new Uri("https://physiotherapistwebservice.azurewebsites.net/api/");
            });

            services.AddDbContext<FysioDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), mig => mig.MigrationsAssembly("FysioAvansWebApp.Infra")));

            services.AddDbContext<AuthDbFysioAvansWebAppContext>(options =>
                        options.UseSqlServer(
                            Configuration.GetConnectionString("AuthDbFysioAvansWebAppContextConnection")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddRazorPages();

            //Repos
            services.AddScoped<IPersonRepo, SQLPersonRepository>();
            services.AddScoped<IRoletypeRepo, SQLRoletypeRepository>();
            services.AddScoped<IPatientDetailRepo, SQLPatientDetailRepository>();
            services.AddScoped<IPhysiotherapistDetailRepo, SQLPhysiotherapistDetailRepository>();
            services.AddScoped<ITreatmentDetailRepo, SQLTreatmentDetailRepository>();
            services.AddScoped<IAvailabilityDetailRepo, SQLAvailabilityDetailRepository>();
            services.AddScoped<IPatientFileRepo, SQLPatientFileRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
