using fan_page.Models;
using Microsoft.EntityFrameworkCore;

namespace fan_page.Infraestrutura
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FanPageDB;Trusted_Connection=true;");
        }

    }
}
