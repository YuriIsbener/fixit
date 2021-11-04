using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace fixit_API.Domains
{
    public partial class fixit_dbContext : DbContext
    {
        public fixit_dbContext()
        {
        }

        public fixit_dbContext(DbContextOptions<fixit_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chamada> Chamada { get; set; }
        public virtual DbSet<Chamater> Chamaters { get; set; }
        public virtual DbSet<Colaborador> Colaboradors { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Prestador> Prestadors { get; set; }
        public virtual DbSet<Setor> Setors { get; set; }
        public virtual DbSet<Statuschamadum> Statuschamada { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=dev@132;database=fixit_db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamada>(entity =>
            {
                entity.HasKey(e => e.IdChamada)
                    .HasName("PRIMARY");

                entity.ToTable("chamada");

                entity.HasIndex(e => e.ColaboradorFk, "colaborador_fk");

                entity.HasIndex(e => e.PrestadorFk, "prestador_fk");

                entity.HasIndex(e => e.StatusChamadaFk, "statusChamada_fk");

                entity.Property(e => e.IdChamada).HasColumnName("idChamada");

                entity.Property(e => e.ColaboradorFk).HasColumnName("colaborador_fk");

                entity.Property(e => e.DataChamada).HasColumnName("dataChamada");

                entity.Property(e => e.NomeChamado)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nomeChamado");

                entity.Property(e => e.PrestadorFk).HasColumnName("prestador_fk");

                entity.Property(e => e.StatusChamadaFk).HasColumnName("statusChamada_fk");

                entity.HasOne(d => d.ColaboradorFkNavigation)
                    .WithMany(p => p.Chamada)
                    .HasForeignKey(d => d.ColaboradorFk)
                    .HasConstraintName("chamada_ibfk_2");

                entity.HasOne(d => d.PrestadorFkNavigation)
                    .WithMany(p => p.Chamada)
                    .HasForeignKey(d => d.PrestadorFk)
                    .HasConstraintName("chamada_ibfk_1");

                entity.HasOne(d => d.StatusChamadaFkNavigation)
                    .WithMany(p => p.Chamada)
                    .HasForeignKey(d => d.StatusChamadaFk)
                    .HasConstraintName("chamada_ibfk_3");
            });

            modelBuilder.Entity<Chamater>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chamater");

                entity.HasIndex(e => e.ChamadaFk, "chamada_fk");

                entity.HasIndex(e => e.MaterialFk, "material_fk");

                entity.Property(e => e.ChamadaFk).HasColumnName("chamada_fk");

                entity.Property(e => e.MaterialFk).HasColumnName("material_fk");

                entity.HasOne(d => d.ChamadaFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ChamadaFk)
                    .HasConstraintName("chamater_ibfk_2");

                entity.HasOne(d => d.MaterialFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaterialFk)
                    .HasConstraintName("chamater_ibfk_1");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("PRIMARY");

                entity.ToTable("colaborador");

                entity.HasIndex(e => e.SetorColabFk, "setorColab_fk");

                entity.HasIndex(e => e.UsuarioFk, "usuario_fk");

                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");

                entity.Property(e => e.SetorColabFk).HasColumnName("setorColab_fk");

                entity.Property(e => e.UsuarioFk).HasColumnName("usuario_fk");

                entity.HasOne(d => d.SetorColabFkNavigation)
                    .WithMany(p => p.Colaboradors)
                    .HasForeignKey(d => d.SetorColabFk)
                    .HasConstraintName("colaborador_ibfk_2");

                entity.HasOne(d => d.UsuarioFkNavigation)
                    .WithMany(p => p.Colaboradors)
                    .HasForeignKey(d => d.UsuarioFk)
                    .HasConstraintName("colaborador_ibfk_1");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("material");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.NomeMaterial)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nomeMaterial");

                entity.Property(e => e.QuantMaterial).HasColumnName("quantMaterial");
            });

            modelBuilder.Entity<Prestador>(entity =>
            {
                entity.HasKey(e => e.IdPrestador)
                    .HasName("PRIMARY");

                entity.ToTable("prestador");

                entity.HasIndex(e => e.SetorPrestFk, "setorPrest_fk");

                entity.HasIndex(e => e.UsuarioFk, "usuario_fk");

                entity.Property(e => e.IdPrestador).HasColumnName("idPrestador");

                entity.Property(e => e.SetorPrestFk).HasColumnName("setorPrest_fk");

                entity.Property(e => e.UsuarioFk).HasColumnName("usuario_fk");

                entity.HasOne(d => d.SetorPrestFkNavigation)
                    .WithMany(p => p.Prestadors)
                    .HasForeignKey(d => d.SetorPrestFk)
                    .HasConstraintName("prestador_ibfk_2");

                entity.HasOne(d => d.UsuarioFkNavigation)
                    .WithMany(p => p.Prestadors)
                    .HasForeignKey(d => d.UsuarioFk)
                    .HasConstraintName("prestador_ibfk_1");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSetor)
                    .HasName("PRIMARY");

                entity.ToTable("setor");

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.NomeSetor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nomeSetor");
            });

            modelBuilder.Entity<Statuschamadum>(entity =>
            {
                entity.HasKey(e => e.IdStatusChamada)
                    .HasName("PRIMARY");

                entity.ToTable("statuschamada");

                entity.Property(e => e.IdStatusChamada).HasColumnName("idStatusChamada");

                entity.Property(e => e.NomeStatusChamada)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nomeStatusChamada");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("senha");

                entity.Property(e => e.TipoUser).HasColumnName("tipoUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
