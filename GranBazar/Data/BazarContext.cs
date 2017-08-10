using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GranBazar.Models
{
    public partial class BazarContext : DbContext
    {
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<OrdineProdotto> OrdineProdotto { get; set; }
        public virtual DbSet<Prodotto> Prodotto { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordine>().ToTable(nameof(Ordine));
            modelBuilder.Entity<Prodotto>().ToTable(nameof(Prodotto));
            modelBuilder.Entity<Utente>().ToTable(nameof(Utente));
            modelBuilder.Entity<OrdineProdotto>().ToTable(nameof(OrdineProdotto));
            modelBuilder.Entity<OrdineProdotto>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdine, e.IdProdotto });
            });
        }
       
    }
}