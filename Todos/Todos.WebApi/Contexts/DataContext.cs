using Microsoft.EntityFrameworkCore;
using System;
using Todos.WebApi.Entities;

namespace Todos.WebApi.Contexts;

public class DataContext : DbContext
{
    public DbSet<TodoEntity> Todos { get; set; }

    public DataContext(DbContextOptions<DataContext>
        options) : base(options)
            {

            }
}
