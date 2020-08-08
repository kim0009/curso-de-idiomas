using LanguagesCourse.Bunisess;
using LanguagesCourse.Configuration;
using LanguagesCourse.Repository;
using LanguagesCourse.Repository.Base;
using LanguagesCourse.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace LanguagesCourse.Ioc
{
    public static class ServiceContainerExtensions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            var repositoriesTypesToRegister = Assembly.GetAssembly(typeof(IBaseService)).GetExportedTypes()
                .Where(type => !type.IsInterface && type.Name.EndsWith("Service"));

            foreach (var type in repositoriesTypesToRegister)
            {
                var interfaceTypeToRegisterFor = type.GetInterfaces().FirstOrDefault(thisInterface => thisInterface.Name.Contains(type.Name)) ?? type;
                services.AddScoped(interfaceTypeToRegisterFor, type);
            }
        }

        public static void RegisterBunisess(this IServiceCollection services)
        {
            var repositoriesTypesToRegister = Assembly.GetAssembly(typeof(IBaseBunisess)).GetExportedTypes()
                .Where(type => !type.IsInterface && type.Name.EndsWith("Bunisess"));

            foreach (var type in repositoriesTypesToRegister)
            {
                var interfaceTypeToRegisterFor = type.GetInterfaces().FirstOrDefault(thisInterface => thisInterface.Name.Contains(type.Name)) ?? type;
                services.AddScoped(interfaceTypeToRegisterFor, type);
            }
        }

        public static void RegisterContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LanguagesCourseModelContext>();
        }
    }
}