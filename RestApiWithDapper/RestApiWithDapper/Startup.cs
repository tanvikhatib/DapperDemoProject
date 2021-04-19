using APIDemo.DataAccess;
using APIDemo.DataAccess.Interfaces;
using APIDemo.SharedEntities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestApiWithDapper
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
           // services.AddControllers();
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddDbContext<EmployeeInfoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //add the connection string name to get the connection to the sql
            services.AddScoped<IDapper, CommonDataAccess>(); //add the interface and class where the interface is used 
            services.AddCors(); //add cors- this is done to allow any html to connect to other html addresses , in this project this is added to connect angular
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()); //this is added to connect angular and allow any method and any header coming from this html address
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
