using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var tempProdottiInCarrello = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            HttpContext.Session.Remove("prodottiCarrello");
            var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
            HttpContext.Session.Remove("quantitaPerProdotto");

            var utenteLoggato = HttpContext.Session.Get<Utente>("utenteLoggato");

            var tmpUtente =
                from x in context.Utente
                where x.Email == utenteLoggato.Email
                select x;
            
            //funziona
            var ordine = context.Ordine.Add(new Ordine
            {
                Email = utenteLoggato.Email,
                Stato = "Spedito",
                DataOrdine = DateTime.Now,
                EmailNavigation = tmpUtente.First()
            });

            context.SaveChanges();
            


           //funziona
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
           
            return View();
        }
    }
}
 