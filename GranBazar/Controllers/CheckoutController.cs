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

            var utenteLoggato = HttpContext.Session.GetString("utenteLoggato");

            var tmpUtente =
                from x in context.Utente
                where x.Email == utenteLoggato
                select x;

            //funziona

            var ordine = new Ordine
            {
                Email = utenteLoggato,
                Stato = "Spedito",
                DataOrdine = DateTime.Now,
            };

            foreach (var x in tempProdottiInCarrello.Select((value, i) => new { i, value }))
            {
                ordine.OrdineProdotto.Add(new OrdineProdotto
                {
                    IdProdotto = x.value.IdProdotto,
                    Quantita = tempQta[x.i],
                });
            }
              
            



     
            context.SaveChanges();



            /*---------- INSERIMENTO NEL DATABASE CHE FALLISCE ----------
             *Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while updating the entries. See the inner exception for details.'
             Inner Exception
             SqlException: Il nome di oggetto 'OrdineProdotto' non è valido.
             

            OrdineProdotto ordineProdotto = new OrdineProdotto();
            foreach (var x in tempProdottiInCarrello.Select((value, i) => new { i, value }))
            {
                ordineProdotto = new OrdineProdotto();
                ordineProdotto.IdOrdine = ordine.Entity.IdOrdine;
                ordineProdotto.IdProdotto = x.value.IdProdotto;
                ordineProdotto.Quantita = tempQta[x.i];
                //ordineProdotto.IdOrdineNavigation = ordine.Entity;
                //ordineProdotto.IdProdottoNavigation = x.value;
                // context.OrdineProdotto.Attach(ordineProdotto);
                context.OrdineProdotto.Add(ordineProdotto);
            }
            context.SaveChanges();//<-- punto in cui fallisce
            **/
            return View();
        }
    }
}