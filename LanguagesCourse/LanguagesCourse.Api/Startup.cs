using LanguagesCourse.Ioc;
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

            // services.AddDbContext<LanguagesCourseModelContext>(options =>
            //    options.UseSqlServer(this.configuration.GetConnectionString("aluno_online"))
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