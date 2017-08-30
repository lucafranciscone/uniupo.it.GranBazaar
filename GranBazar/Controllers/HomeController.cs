using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using GranBazar.Data;
using GranBazar.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {
        BazarContext Context;
        ILogger Logger;

        public HomeController (BazarContext context, ILogger<ProdottiController> logger)  {
            Context = context;
            Logger = logger;
        }

        public IActionResult Index()
        {
            var catalogoProdotti =
                from x in Context.Prodotto
                select x;


            //devo far ritornare i primi 10 prodotti più acquistati
            var idProdottiAcquistatiOrdinatiUltimo =
              (from o in Context.Ordine_Prodotto
               join p in Context.Prodotto
                on o.IdProdotto equals p.IdProdotto

               select p).OrderByDescending(n => n.IdProdotto)
               .Distinct()
               .Take(10);

            //andrebbe tolta dalla sessione
            HttpContext.Session.Set<List<Prodotto>>("top10",idProdottiAcquistatiOrdinatiUltimo.ToList());

            return View(catalogoProdotti.ToList());


        }
    }
}