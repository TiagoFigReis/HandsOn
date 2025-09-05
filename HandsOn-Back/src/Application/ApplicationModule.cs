using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Application.Services.NutrientTables;
using Application.Services.DataAnalysis;
using Application.Services.Cultures;
using Application.Services.FertilizerTables;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddSingleton(configuration!);
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IAnaliseServices, AnaliseServices>();
            services.AddScoped<INutrientTablesServices, NutrientTablesServices>();
            services.AddScoped<IDataAnalysisServices, DataAnalysisServices>();
            services.AddScoped<ICulturesServices, CulturesServices>();
            services.AddScoped<IFertilizerTablesServices, FertilizerTablesServices>();
            return services;
        }
    }
}