using GamesStore_11883_API.Repository;
using GamesStore_11883_API.DAL_11883;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GamesStore_11883_API
{
    public class Startup
    {
        private const string DataDirectory = "|DataDirectory|";
        private string _appPath;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<GameContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("GameAPIDB")
                .Replace(DataDirectory, _appPath))
                );
            services.AddControllers();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _appPath = Path.Combine(env.ContentRootPath, "AppData");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
