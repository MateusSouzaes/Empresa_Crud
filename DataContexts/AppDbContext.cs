using CRUD_Empresa.Models;
using Microsoft.EntityFrameworkCore;


namespace CRUD_Empresa.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
