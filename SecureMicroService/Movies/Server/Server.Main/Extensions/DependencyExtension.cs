
using System.Reflection;

namespace Server.Main.Extensions
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ILogger<Startup> logger = services
                           .BuildServiceProvider()
                           .GetRequiredService<ILogger<Startup>>();

            services.AddSwaggerService(configuration);
            services.AddMemoryCache();

            // Options
            services.AddOptions();

            // Swagger
            //services.AddSwaggerService(configuration);

            // Add Database Context
            services.AddDatabaseContextService(configuration, logger);
            services.AddScoped<ISession>(provider =>
            provider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext
                .Session);
            //services.AddSwaggerService(configuration);

            //services.AddScoped<ISystemManager, SystemManager>();
            //services.AddScoped<IProductManager, ProductManager>();

            return services;
        }

        public static IApplicationBuilder UseDependencies(
            this IApplicationBuilder app,
            IConfiguration configuration,
            //ILoggerFactory loggerFactory,
          
            IServiceProvider serviceProvider
        )
        {
            //app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.UseSwaggerService();

            //app.UseStaticFilesService();

            //app.UseCorsServices(configuration);

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseScheduler(recurringJobManager, serviceProvider, new List<Assembly> { typeof(EmailCampaignScheduledJobExecutor).Assembly });

            app.UseAuthentication();

            app.UseAuthorization();
            return app;
        }
    }
}
