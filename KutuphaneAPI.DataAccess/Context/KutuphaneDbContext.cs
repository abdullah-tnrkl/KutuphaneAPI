using KutuphaneAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneAPI.DataAccess.Context
{
    public class KutuphaneDbContext : DbContext
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options) : base(options) { }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<KitapOdunc> KitapOduncIslemleri { get; set; }

        public DbSet<IslemLogu> IslemLoglari { get; set; }

        public DbSet<LogKaydi> LogKayitlari { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişki tanımlamaları
            modelBuilder.Entity<Kitap>()
                .HasMany(k => k.OduncBilgileri)
                .WithOne(o => o.Kitap)
                .HasForeignKey(o => o.KitapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
