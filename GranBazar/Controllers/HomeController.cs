using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {

         public IActionResult Index() => View();

        // public IActionResult Prodotti() => View();

        //"index" � la Action, che per noi adesso � solo l'unico file dentro Views/Prodotti
        //"Prodotti" � il nome del controller
        //E' tutto case sensitive, bisogna fare attenzione alla dichirazione dei nomi
        //public IActionResult Index() => Redirect(Url.Action("Index", "Prodotti"));
    }
}