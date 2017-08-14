using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Models;
using Microsoft.AspNetCore.Http;
using GranBazar.Src;

namespace GranBazar.Controllers
{
    public class CarrelloController : Controller
    {

        BazarContext Context;
        List<Prodotto> prodottiInCarrello;
        public CarrelloController(BazarContext context)
        {
            Context = context;
        }


        //dobbiamo mettere le cose in sessione, così non funziona
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                var query =
                    from x in Context.Prodotto
                    where x.IdProdotto == id
                    select x;

                var temp = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");

                if (temp != null)
                {
                    temp.Add(query.First());
                    HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", temp);
                }
                else
                {
                    prodottiInCarrello = new List<Prodotto>();
                    prodottiInCarrello.Add(query.First());
                    HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", prodottiInCarrello);
                }

            }
           // HttpContext.Session.SetInt32("id",id);

            //var t = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            //System.Console.WriteLine($"Nel carrello ci sono: {t.First().NomeProdotto}");
            return View();
        }

       
        public IActionResult RimuoviProdotto(int id)
        {
            var query =
                from x in Context.Prodotto
                where x.IdProdotto == id
                select x;

            var temp = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");

            temp.Remove(query.First());
            HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", temp);

            return Redirect("/Carrello/Index");
        }


    }
}