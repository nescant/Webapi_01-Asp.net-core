using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Webapi_01.Models;

namespace Webapi_01
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Postads> Posts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}



