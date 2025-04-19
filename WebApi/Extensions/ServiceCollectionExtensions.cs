
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Impl.Services;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
      
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Program));

            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IBookService, FakeBookService>();

            return services;
        }

    }
}
