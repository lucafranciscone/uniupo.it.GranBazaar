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
using Microsoft.AspNetCore.Diagnostics;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {
        BazarContext context;

        public HomeController (BazarContext context)  {
            this.context = context;
        }

        public IActionResult Index()
        {
            /*
             * Seleziono i prodotti acquistati nell'ultimo mese,
             * per farlo controllo che la data dell'ordine del sia > della data di oggi - 1 mese
             * Poi raggruppo per codice prodotto e prendo solo il primo
             * */
            var query = (
                from prodotti in context.Prodotto
                join ordiniProdotti in context.Ordine_Prodotto on prodotti.IdProdotto equals ordiniProdotti.IdProdotto
                join ordini in context.Ordine on ordiniProdotti.IdOrdine equals ordini.IdOrdine
                where ordini.DataOrdine > DateTime.Now.AddMonths(-1)
                orderby ordiniProdotti.Quantita descending
                select prodotti
                ).GroupBy(p => p.IdProdotto).Select(y => y.First()).Take(10);

                return View(query.ToList());
        }

    }
}