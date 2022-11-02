using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Models;

namespace ProjetosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movimento>()
                .HasOne(movimento => movimento.Material)
                .WithMany(material => material.Movimento)
                .HasForeignKey(movimento => movimento.MaterialId);

            builder.Entity<Categoria>()
                .HasOne(categoria => categoria.Projeto)
                .WithOne(projeto => projeto.Categoria)
                .HasForeignKey<Projeto>(projeto => projeto.CategoriaId);

            builder.Entity<Anotacao>()
                .HasOne(anotacao => anotacao.Projeto)
                .WithMany(projeto => projeto.Anotacoes)
                .HasForeignKey(anotacao => anotacao.ProjetoId);

            builder.Entity<Imagem>()
                .HasOne(imagem => imagem.Projeto)
                .WithMany(projeto => projeto.Imagens)
                .HasForeignKey(imagem => imagem.ProjetoId);

            builder.Entity<Video>()
                .HasOne(video => video.Projeto)
                .WithMany(projeto => projeto.Videos)
                .HasForeignKey(video => video.ProjetoId);
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Anotacao> Anotacao { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
    }
}

