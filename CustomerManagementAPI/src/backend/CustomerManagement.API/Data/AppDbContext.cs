using CustomerManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; } // Existe uma coleção de Clientes que será representada na base de dados
}
