using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GranBazar.Data
{
    /*
     * Classe utiliizzata per avere accesso ai dati
     * */
    public class GranBazarContext : DbContext
    {
        public GranBazarContext(DbContextOption<GranBazarContext> options) : base(options)
        { }

        public DbSet<Carrello> Carrello { get; set; }

        public DbSet<Contiene> Contiene { get; set; }

        public DbSet<Ordine> Ordine { get; set; }

        public DbSet<Prodotto> Prodotto { get; set; }

        public DbSet<Utente> Utente { get; set; }


    }
}
