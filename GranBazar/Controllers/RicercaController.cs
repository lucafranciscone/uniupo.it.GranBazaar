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
            if(search==null)
            {
                return View();
            }
            
            var prodottiContenentiSerach =
                   from x in context.Prodotto
                   where x.DescrizioneProdotto.Contains(search) || x.NomeProdotto.Contains(search)
                   orderby x.Prezzo descending
                   select x;

           

            return View((List<Prodotto>)prodottiContenentiSerach.ToList());
        }
    }
}