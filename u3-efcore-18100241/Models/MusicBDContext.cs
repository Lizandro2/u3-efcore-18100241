using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace u3_efcore_18100241.Models
{
    public partial class MusicBDContext : DbContext
    {
        public MusicBDContext()
        {
        }

        public MusicBDContext(DbContextOptions<MusicBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artista> Artistas { get; set; }
        public virtual DbSet<Cancione> Canciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MusicBD;User=sa;Password=sa;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.HasKey(e => e.IdArtista)
                    .HasName("PK_ARTISTAS");

                entity.ToTable("artistas");

                entity.Property(e => e.IdArtista).HasColumnName("id_artista");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cancione>(entity =>
            {
                entity.HasKey(e => e.IdCancion)
                    .HasName("PK_CANCIONES");

                entity.ToTable("canciones");

                entity.Property(e => e.IdCancion).HasColumnName("id_cancion");

                entity.Property(e => e.IdArtista).HasColumnName("id_artista");

                entity.Property(e => e.NombreCancion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cancion");

                entity.HasOne(d => d.IdArtistaNavigation)
                    .WithMany(p => p.Canciones)
                    .HasForeignKey(d => d.IdArtista)
                    .HasConstraintName("FK_CANCIONES_ARTISTAS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
