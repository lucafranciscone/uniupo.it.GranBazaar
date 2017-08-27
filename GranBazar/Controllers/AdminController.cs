using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GranBazar.Data;
using GranBazar.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GranBazar.Controllers
{
    public class AdminController : Controller
    {
        BazarContext Context;
        ILogger Logger;

        public AdminController(BazarContext context, ILogger<ProdottiController> logger)
        {
            Context = context;
            Logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatalogoProdotti()
        {

            var catalogoProdotti =
                from p in Context.Prodotto
                select p;

            return View(catalogoProdotti.ToList());
        }

        // da implementare 

        //http://kerryritter.com/updating-or-replacing-entities-in-entity-framework-6/#comment-202
        //https://stackoverflow.com/questions/25894587/how-to-update-record-using-entity-framework-6


        //arriva 
        //http://localhost:54575/Admin/AggiornaDisponibilitaProdotto?idProdotto=%3E12&stato=true
        //dovrebbe arrivare
        //http://localhost:54575/Admin/AggiornaDisponibilitaProdotto?idProdotto=13&stato=false
        public IActionResult AggiornaDisponibilitaProdotto(int? idProdotto, bool? stato)
        {
            //IQueryable<Prodotto> catalogoProdotti = null;


            //CASO IN CUI DEVO AGGIORNARE
            if (idProdotto!=null && stato!=null)
            {
                Boolean update = false;
                if (stato.Equals("true"))
                {
                    update = true;
                }
                var prodottoDaAggiornare = 
                    from prod in Context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;

                Prodotto p = prodottoDaAggiornare.SingleOrDefault();
                p.Disponibile = update;
                Context.SaveChanges();

                //Ristampo la lista aggiornata
                var catalogoProdotti =
                from prod in Context.Prodotto
                select prod;
                return View(catalogoProdotti.ToList());

            }
            else
            {
                var catalogoProdotti =
                from prod in Context.Prodotto
                select prod;
                return View(catalogoProdotti.ToList());

            }
        }
    }

    /*
    public class AdminController : CrudController<BazarContext, string, Utente>
    {
        public AdminController(BazarContext context, ILogger<AdminController> logger) : base(context, logger) {}

        protected override DbSet<Utente> Entities => Context.Utente;

        protected override Func<Utente, string, bool> FilterById => (e, id) => e.Email == id;


    }*/

}