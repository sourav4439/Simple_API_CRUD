using DigitalPrescription.Data;
using DigitalPrescription.Data.Interfaces;
using DigitalPrescription.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DigitalPrescription
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
            services.AddDbContextPool<AppDb>(
                option => option.UseSqlServer(
                    Configuration.GetConnectionString("DigitalPrescriptionDB")));
            services.AddScoped<IAdviceRepo,AdviceRepo>();
            services.AddScoped<ICategorymedRepo,CategorymedRepo>();
            services.AddScoped<ICcRepo,CcRepo>();
            services.AddScoped<ICfRepo,CfRepo>();
            services.AddScoped<IMedCompanyRepo,MedCompanyRepo>();
            services.AddScoped<IOhRepo,OhRepo>();
            services.AddScoped<IPatientRepo,PatientRepo>();
            services.AddScoped<IMedicineRepo,MedicineRepo>();

            services.AddControllers();
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
