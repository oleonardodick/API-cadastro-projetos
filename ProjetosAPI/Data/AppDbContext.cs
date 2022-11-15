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
                .WithMany(material => material.Movimentos)
                .HasForeignKey(movimento => movimento.MaterialId);

            builder.Entity<Projeto>()
                .HasOne(projeto => projeto.Categoria)
                .WithMany(categoria => categoria.Projetos)
                .HasForeignKey(projeto => projeto.CategoriaId);

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

            builder.Entity<MaterialProjeto>()
                .HasOne(matProjeto => matProjeto.Material)
                .WithMany(material => material.MateriaisProjeto)
                .HasForeignKey(matprojeto => matprojeto.MaterialId);

            builder.Entity<MaterialProjeto>()
                .HasOne(matProjeto => matProjeto.Projeto)
                .WithMany(projeto => projeto.MateriaisProjeto)
                .HasForeignKey(matprojeto => matprojeto.ProjetoId);

            builder.Entity<ProdutoPronto>()
                .HasOne(prodPronto => prodPronto.Projeto)
                .WithMany(projeto => projeto.ProdutosProntos)
                .HasForeignKey(prodPronto => prodPronto.ProjetoId);

            builder.Entity<MovimentoProjeto>()
                .HasOne(mov => mov.ProdutoPronto)
                .WithMany(prodPronto => prodPronto.Movimentos)
                .HasForeignKey(mov => mov.ProdutoProntoId);

            builder.Entity<OrdemProducao>()
                .HasOne(ordem => ordem.Projeto)
                .WithMany(projeto => projeto.OrdensProducao)
                .HasForeignKey(ordem => ordem.ProjetoId);

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Anotacao> Anotacao { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ProdutoPronto> ProdutoPronto { get; set; }
        public DbSet<MovimentoProjeto> MovimentoProjeto { get; set; }
        public DbSet<MaterialProjeto> MaterialProjeto { get; set; }
        public DbSet<OrdemProducao> OrdemProducao { get; set; }
    }
}

