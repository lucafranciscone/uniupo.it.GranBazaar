using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GranBazar.Models;

namespace GranBazar.Data
{
    /*
     * Classe utiliizzata per avere accesso ai dati
     * */
    public partial class BazarContext : DbContext
    {

        //public BazarContext(DbContextOptions<BazarContext> options) : base(options) { }

        //utilizziamo un altro modo per connetterci al db, rispetto al prof, usando UseSqlServer sotto e non appsettings.json
        //questa cosa la dobbiamo risolvere


        public virtual DbSet<Carrello> Carrello { get; set; }
        public virtual DbSet<Contiene> Contiene { get; set; }
        public virtual DbSet<Ordine> Ordine { get; set; }
        public virtual DbSet<Prodotto> Prodotto { get; set; }
        public virtual DbSet<Utente> Utente { get; set; }

        /*
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrello>().ToTable(nameof(Carrello));
            modelBuilder.Entity<Contiene>().ToTable(nameof(Contiene));
            modelBuilder.Entity<Ordine>().ToTable(nameof(Ordine));
            modelBuilder.Entity<Prodotto>().ToTable(nameof(Prodotto));
            modelBuilder.Entity<Utente>().ToTable(nameof(Utente));
        }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8RDCTOV; Database=Bazar; Trusted_Connection=True;");
             
        }


        //questa parte fa funzionare, ma è estremamente lenta all'inizio

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrello>(entity =>
            {
                entity.HasKey(e => e.IdCarrello)
                    .HasName("PK__Carrello__0A279D70F78788C8");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Carrello__A9D10534BAEFFDE7")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmailNavigation)
                    .WithOne(p => p.Carrello)
                    .HasForeignKey<Carrello>(d => d.Email)
                    .HasConstraintName("FK__Carrello__Email__2E1BDC42");
            });

            modelBuilder.Entity<Contiene>(entity =>
            {
                entity.HasKey(e => new { e.IdCarrello, e.IdProdotto, e.IdOrdine })
                    .HasName("PK__Contiene__78C24D84BFA413B7");

                entity.HasIndex(e => e.IdOrdine)
                    .HasName("UQ__Contiene__D8C50D2EEB6DB4EE")
                    .IsUnique();

                entity.HasOne(d => d.IdCarrelloNavigation)
                    .WithMany(p => p.Contiene)
                    .HasForeignKey(d => d.IdCarrello)
                    .HasConstraintName("FK__Contiene__IdCarr__403A8C7D");

                entity.HasOne(d => d.IdOrdineNavigation)
                    .WithOne(p => p.Contiene)
                    .HasForeignKey<Contiene>(d => d.IdOrdine)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Contiene__IdOrdi__4222D4EF");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany(p => p.Contiene)
                    .HasForeignKey(d => d.IdProdotto)
                    .HasConstraintName("FK__Contiene__IdProd__412EB0B6");
            });

            modelBuilder.Entity<Ordine>(entity =>
            {
                entity.HasKey(e => e.IdOrdine)
                    .HasName("PK__Ordine__D8C50D2F9A38AB59");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Stato).IsRequired();

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.Ordine)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Ordine__Email__29572725");
            });

            modelBuilder.Entity<Prodotto>(entity =>
            {
                entity.HasKey(e => e.IdProdotto)
                    .HasName("PK__Prodotto__C3D15F947CC2B55C");

                entity.Property(e => e.DescrizioneProdotto).IsRequired();

                entity.Property(e => e.LinkImmagine).HasMaxLength(1);

                entity.Property(e => e.NomeProdotto).IsRequired();

                entity.Property(e => e.Prezzo).HasColumnType("decimal");
            });

            modelBuilder.Entity<Utente>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Utente__A9D105357606C33A");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Psw).IsRequired();

                entity.Property(e => e.Ruolo).IsRequired();
            });
        }
        
    }
}