using Microsoft.EntityFrameworkCore;
using PesquisaItensAPI.Models;

namespace PesquisaItensAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Item> Itens { get; set; }
        public DbSet<ItemPesquisa> ItemPesquisas { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbOptions): base(dbOptions)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Itens
            modelBuilder.Entity<Item>()
                .Property(item => item.Descricao)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(item => item.Tipo)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(item => item.Modelo)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(item => item.Marca)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .HasMany(item => item.ItemPesquisas)
                .WithOne(item => item.Item)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region ItemPesquisas
            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.Local)
                .IsRequired();

            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.Link)
                .IsRequired();

            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.Preco)
                .IsRequired();

            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.PrecoPrazo)
                .IsRequired();

            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.PrecoFrete)
                .IsRequired();

            modelBuilder.Entity<ItemPesquisa>()
                .Property(pesquisa => pesquisa.DataPesquisa)
                .IsRequired();
            #endregion
        }
    }
}
