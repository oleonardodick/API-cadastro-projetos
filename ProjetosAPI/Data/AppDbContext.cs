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
            //builder.Entity<Endereco>()
            //    .HasOne(endereco => endereco.Cinema)
            //    .WithOne(cinema => cinema.Endereco)
            //    .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            //builder.Entity<Cinema>()
            //    .HasOne(cinema => cinema.Gerente)
            //    .WithMany(gerente => gerente.Cinemas)
            //    .HasForeignKey(cinema => cinema.GerenteId);

            //builder.Entity<Sessao>()
            //    .HasOne(sessao => sessao.Filme)
            //    .WithMany(filme => filme.Sessoes)
            //    .HasForeignKey(sessao => sessao.FilmeId);

            //builder.Entity<Sessao>()
            //   .HasOne(sessao => sessao.Cinema)
            //   .WithMany(cinema => cinema.Sessoes)
            //   .HasForeignKey(sessao => sessao.CinemaId);
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Anotacao> Anotacao { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
    }
}

