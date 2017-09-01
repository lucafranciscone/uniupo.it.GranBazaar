using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using GranBazar.Models;
using GranBazar.Data;

namespace GranBazar.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {

        BazarContext context;

        public CheckoutController(BazarContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            //ottengo e rimuovo i prodotti e le relative quantità dal carrello
            var tempProdottiInCarrello = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            HttpContext.Session.Remove("prodottiCarrello");
            var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
            HttpContext.Session.Remove("quantitaPerProdotto");
            HttpContext.Session.Remove("numeroElementiInCarrello");

            var utenteLoggato = HttpContext.Session.Get<Utente>("utenteLoggato");

            //Solo gli utenti posso acquistare, questo controllo serve per escludere gli Admin
            if(utenteLoggato.Ruolo.Equals("User"))
            {
                var tmpUtente =
                from x in context.Utente
                where x.Email == utenteLoggato.Email
                select x;

                var ordine = context.Ordine.Add(new Ordine
                {
                    Email = utenteLoggato.Email,
                    Stato = "Spedito",
                    DataOrdine = DateTime.Now,
                    EmailNavigation = tmpUtente.First(),
                });

                context.SaveChanges();

                Ordine_Prodotto ordineProdotto = new Ordine_Prodotto();

                foreach (var x in tempProdottiInCarrello.Select((value, i) => new { i, value }))
                {
                    ordineProdotto = new Ordine_Prodotto();
                    ordineProdotto.IdOrdine = ordine.Entity.IdOrdine;
                    ordineProdotto.IdProdotto = x.value.IdProdotto;
                    ordineProdotto.Quantita = tempQta[x.i];
                    context.Ordine_Prodotto.Add(ordineProdotto);
                }
                context.SaveChanges();

                //ordine piazzato e caricato sul db, rimando utente nella sua area riservata
                return RedirectToAction("AreaRiservataUser", "Account");
            }

            //Mi loggo come Admin, vengo rimandato su HomePage
            return RedirectToAction("Index", "Home");
        }
    }
}
 