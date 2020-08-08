using AutoMapper;
using LanguagesCourse.Ioc;
using LanguagesCourse.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LanguagesCourse.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterService();
            services.RegisterBunisess();
            services.RegisterContext();
            services.RegisterProfile();

            // services.AddDbContext<LanguagesCourseModelContext>(options =>
            //    options.UseSqlServer(this.configuration.GetConnectionString("db"))
            //);

            services.AddCors();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());

            app.UseMvc();
        }
    }
}