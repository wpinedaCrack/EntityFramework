using DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Datos
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<nota> notas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new { ae.Etiqueta_Id , ae.Articulo_Id });
        }
    }
}
