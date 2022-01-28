using EasyDonation.Dominio;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Infra.Data.Contexts
{
    public class EasyDonationContext : DbContext
    {
        public EasyDonationContext(DbContextOptions<EasyDonationContext> options) : base(options){}

        // Tabelas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Modelagem do Banco
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.NomeUsuario).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.NomeUsuario).IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).IsRequired();

            #endregion

            #region Doações
            modelBuilder.Entity<Doacao>().ToTable("Doações");
            modelBuilder.Entity<Doacao>().Property(x => x.Id);
            modelBuilder.Entity<Doacao>().Property(x => x.Id).IsRequired();

            modelBuilder.Entity<Doacao>().Property(x => x.Imagem).HasMaxLength(255);
            modelBuilder.Entity<Doacao>().Property(x => x.Imagem).IsRequired();

            modelBuilder.Entity<Doacao>().Property(x => x.Titulo).HasMaxLength(255);
            modelBuilder.Entity<Doacao>().Property(x => x.Titulo).IsRequired();

            modelBuilder.Entity<Doacao>().Property(x => x.Descricao).HasMaxLength(255);
            modelBuilder.Entity<Doacao>().Property(x => x.Descricao).IsRequired();

            modelBuilder.Entity<Doacao>().Property(x => x.StatusDoacao).IsRequired();

            modelBuilder.Entity<Doacao>().Property(x => x.IdUsuario).IsRequired();
            modelBuilder.Entity<Doacao>().Property(x => x.IdCategoria).IsRequired();
            #endregion

            #region Categoria
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Categoria>().Property(x => x.Id);
            modelBuilder.Entity<Categoria>().Property(x => x.Id).IsRequired();

            modelBuilder.Entity<Categoria>().Property(x => x.NomeCategoria).HasMaxLength(255);
            modelBuilder.Entity<Categoria>().Property(x => x.NomeCategoria).IsRequired();

            modelBuilder.Entity<Categoria>().Property(x => x.StatusCategoria).IsRequired();

            //modelBuilder.Entity<Categoria>().Property(x => x.DescricaoCategoria).IsRequired();

            //modelBuilder.Entity<Categoria>().Property(x => x.ImageCategoria).IsRequired();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
