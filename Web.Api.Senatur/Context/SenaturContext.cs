using Microsoft.EntityFrameworkCore;
using Senai.Web.Api.Senatur.Domains;

namespace Senai.Web.Api.Senatur.Context {
    public class SenaturContext : DbContext {

        /// <summary>
        /// Tabela de usuarios
        /// </summary>
        public DbSet<UsuariosDomain> Usuarios{ get ; set; }

        /// <summary>
        /// Tabela de pacotes
        /// </summary>
        public DbSet<PacotesDomain> Pacotes { get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             optionsBuilder.UseSqlServer(
                "Data Source =.\\MEUSERVIDOR; initial catalog = Senatur_Manha; user id = sa; pwd = 132"
            );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
