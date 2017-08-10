using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using GranBazar.Data;
using GranBazar.Models;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Query query = new Query();

            //è un esempio di come mettere i dati e visualizzarli in html
           // ViewData["numberProductsInCart"] = query.getumberProductsInCart();


            return View();
        }



        // public IActionResult Prodotti() => View();

        //"index" è la Action, che per noi adesso è solo l'unico file dentro Views/Prodotti
        //"Prodotti" è il nome del controller
        //E' tutto case sensitive, bisogna fare attenzione alla dichirazione dei nomi
        //public IActionResult Index() => Redirect(Url.Action("Index", "Prodotti"));
    }
}