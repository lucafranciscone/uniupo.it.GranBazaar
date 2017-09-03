using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Models;
using GranBazar.Data;

namespace GranBazar.Controllers
{
    public class RicercaController : Controller
    {

        BazarContext context;
    
        public RicercaController(BazarContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string search)
        {
            /*se l'utente clicca sul bottone cerca ma non inserisce nulla rimando nella home page*/
            if(search==null)
            {
                return RedirectToAction("Index","Home");
            }
            
            var prodottiContenentiSerach =
                   from x in context.Prodotto
                   where x.DescrizioneProdotto.Contains(search) || x.NomeProdotto.Contains(search)
                   orderby x.Prezzo descending
                   select x;

            /*Nel caso la ricerca non produca risultati non sarebbe meglio riportare qualche scritta o qualcosa del genere?*/


            return View((List<Prodotto>)prodottiContenentiSerach.ToList());
        }
    }
}