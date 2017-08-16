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

            var query =
                from x in Context.Prodotto
                select x;


            //è un esempio di come mettere i dati e visualizzarli in html
            // ViewData["numberProductsInCart"] = query.getumberProductsInCart();
            foreach (var x in query)
                System.Console.WriteLine(x);

            return View(query.ToList());
        }



        // public IActionResult Prodotti() => View();

        //"index" è la Action, che per noi adesso è solo l'unico file dentro Views/Prodotti
        //"Prodotti" è il nome del controller
        //E' tutto case sensitive, bisogna fare attenzione alla dichirazione dei nomi
        //public IActionResult Index() => Redirect(Url.Action("Index", "Prodotti"));
    }
}