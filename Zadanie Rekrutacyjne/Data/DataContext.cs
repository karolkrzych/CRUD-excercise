using Microsoft.EntityFrameworkCore;
using Zadanie_Rekrutacyjne.Models;

namespace Zadanie_Rekrutacyjne.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCreateInputModel> _Products { get; set; }
    }
}