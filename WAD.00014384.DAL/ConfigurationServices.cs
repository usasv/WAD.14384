using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WAD._00014384.DAL.Data;
using WAD._00014384.DAL.Interfaces;
using WAD._00014384.DAL.Repositories;

namespace WAD._00014384.DAL
{
    public static class ConfigrationDAL
    {
        public static IServiceCollection AddConfigurationServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
