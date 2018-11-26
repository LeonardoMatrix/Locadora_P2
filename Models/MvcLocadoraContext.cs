using Microsoft.EntityFrameworkCore;

namespace Locadora.Models
{
    public class MvcLocadoraContext : DbContext
    {
        public MvcLocadoraContext (DbContextOptions<MvcLocadoraContext> options)
            : base(options)
        {
        }

        public DbSet<Locadora.Models.Ator> Ator { get; set; }
        public DbSet<Locadora.Models.DVD> DVD { get; set; }
        public DbSet<Locadora.Models.Locacao> Locacao { get; set; }
         public DbSet<Locadora.Models.Sessao> Sessao { get; set; }
         public DbSet<Locadora.Models.Video> Videos { get; set; }
         public DbSet<Locadora.Models.Cliente> Cliente { get; set; }
    }
}