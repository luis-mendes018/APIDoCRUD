using System.Data.Entity;
using ClienteMVC.Models;


namespace ClienteMVC.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext() : base("ClienteContext")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}