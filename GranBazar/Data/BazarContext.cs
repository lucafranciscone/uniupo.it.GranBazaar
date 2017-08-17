using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GranBazar.Models;

namespace GranBazar.Data
{
    public partial class BazarContext : DbContext
    {
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<Ordine_Prodotto> Ordine_Prodotto { get; set; }
        public virtual DbSet<Prodotto> Prodotto { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }

        public BazarContext(DbContextOptions<BazarContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordine>().ToTable(nameof(Ordine));
            modelBuilder.Entity<Prodotto>().ToTable(nameof(Prodotto));
            modelBuilder.Entity<Utente>().ToTable(nameof(Utente));
            modelBuilder.Entity<Ordine_Prodotto>().ToTable(nameof(Ordine_Prodotto));
            modelBuilder.Entity<Ordine_Prodotto>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdine, e.IdProdotto });
            });
        }
       
    }
}