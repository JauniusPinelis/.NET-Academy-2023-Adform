using Infrastructure.Clients;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.WebApi.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("MyDatabase"));
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<JsonPlaceholderClient>();
            services.AddHttpClient();
        }
    }
}
