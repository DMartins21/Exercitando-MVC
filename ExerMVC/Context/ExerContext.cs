using ExerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerMVC.Context
{
    public class ExerContext : DbContext
    {
        public ExerContext(DbContextOptions<ExerContext> options) : base(options)
        { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
