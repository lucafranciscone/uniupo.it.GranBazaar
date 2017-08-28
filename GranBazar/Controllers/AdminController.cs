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



        /*
         * Catalogo prodotti: elenco di tutti i prodotti a catalogo (non è obbligatorio implementare
            l’interfaccia per il caricamento dei prodotti) con possibilità di cambiarne il prezzo,
            l’eventuale sconto e la disponibilità (sì/no)
         * */

        //http://localhost:54575/Admin/AggiornaDisponibilitaProdotto?idProdotto=12&stato=true&sconto=10
        //http://localhost:54575/Admin/AggiornaDisponibilitaProdotto?idProdotto=12&stato=true&sconto=10&prezzo=10.10

        public IActionResult AggiornaDisponibilitaProdotto(int? idProdotto, bool? stato,decimal prezzo,int sconto)
        {
            //aggiorno il prezzo
            if(prezzo!=null && idProdotto !=null && prezzo>0)
            {    
       
                //recupero il prodotto da aggiornare
                var prodottoDaAggiornare =
                    from prod in Context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;

                Prodotto p = prodottoDaAggiornare.SingleOrDefault();
                p.Prezzo = prezzo;
                Context.SaveChanges();
            }
            
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

            }

            if(sconto!=null && sconto>0 && idProdotto!=null)
            {
                //recupero il prodotto da aggiornare
                var prodottoDaAggiornare =
                    from prod in Context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;
                Prodotto p = prodottoDaAggiornare.SingleOrDefault();
                p.Sconto = (byte)sconto;
                Context.SaveChanges();
            }
           
           
                var catalogoProdotti =
                from prod in Context.Prodotto
                select prod;
                return View(catalogoProdotti.ToList());

           
        }


        /*l' Elenco degli utenti registrati con possibilità eventuale di cambiare il ruolo. Un utente
        registrato assume di default il ruolo User
         * */
        public IActionResult ElencoUtenti(string email, string ruolo)
        {
            if(email != null && ruolo != null && (ruolo.Equals("Admin") || ruolo.Equals("User")))
            {
                var utenteDaAggiornare =
                     from user in Context.Utente
                     where user.Email.Equals(email)
                     select user;
                Utente u = utenteDaAggiornare.SingleOrDefault();
                u.Ruolo = ruolo;
                Context.SaveChanges();
            }

            var utente =
                  from user in Context.Utente
                  select user;
            return View(utente.ToList());

        }
        /*
         * Elenco degli ordini effettuati con possibilità di cambiare lo stato di un ordine da Sent a
            Processed. Per ogni ordine deve essere possibile vedere i dettagli (da quale utente è
            stato fatto, quando, prodotti acquistati, prezzo di acquisto, ...). L’elenco deve essere
        filtrabile.
         * 
         * */
        public IActionResult ElencoOrdini(int? idProdotto, bool? stato)
        {
            return View();

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