using System.Data.Entity;

namespace CrudAspNetMvc.Models
{
    public class CadastroContext : DbContext
    {
        public CadastroContext() : base("Cadastro")
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}