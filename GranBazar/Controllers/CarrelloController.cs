using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Models;

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
        public IActionResult Index(int id)
        {
            var query =
                from x in Context.Prodotto
                where x.IdProdotto == id
                select x;

            if (prodottiInCarrello != null)
            {
                prodottiInCarrello.Add(query.First());
            }
            else {
                prodottiInCarrello = new List<Prodotto>();
                prodottiInCarrello.Add(query.First());
            }

            

            ViewBag.ProdottiLista = prodottiInCarrello;

            return View();
        }

       
        public IActionResult RimuoviProdottoInCarrello(Prodotto p)
        {
            if (p != null)
            {
                prodottiInCarrello.Remove(p);
            }
            return View(p);
        }


    }
}