using System.Data.Entity;

namespace roboapi.Models
{
    public class context : DbContext
    {
        public DbSet<BracoDireito> BracoDireitoes { get; set; }

        public DbSet<BracoEsquerdo> BracoEsquerdoes { get; set; }

        public DbSet<Cabeca> Cabecas { get; set; }
    }
}