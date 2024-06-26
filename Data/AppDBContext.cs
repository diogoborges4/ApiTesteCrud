using ApiTesteCrud.Products;
using Microsoft.EntityFrameworkCore;

namespace ApiTesteCrud.Data;

public class AppDBContext : DbContext
{
    public DbSet<ProductsModel> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "Data Source=Bancp.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}