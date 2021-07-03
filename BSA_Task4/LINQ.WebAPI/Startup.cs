using LINQ.BL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LINQ.BL.MappingSettings;
using LINQ.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LINQ.WebAPI
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

            services.AddScoped<ProjectService>();
            services.AddScoped<TaskService>();
            services.AddScoped<UserService>();
            services.AddScoped<TeamService>();

            services.AddAutoMapper(conf=> {
                conf.AddProfile<MapProject>();
                conf.AddProfile<MapTask>();
                conf.AddProfile<MapUser>();
                conf.AddProfile<MapTeam>();
            });

            services.AddDbContext<LINQDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
