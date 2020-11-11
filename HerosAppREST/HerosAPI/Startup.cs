using HerosDB;
using HerosDB.Entities;
using HerosLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HerosAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowedOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1:5500/AllHeroes.html").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers();
            services.AddDbContext<HeroContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HerosDB")));
            services.AddScoped<IHeroService, HeroService>();
            services.AddScoped<ISuperHeroRepo, DBRepo>();
            services.AddScoped<IMapper, DBMapper>();
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

            app.UseCors("AllowedOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}