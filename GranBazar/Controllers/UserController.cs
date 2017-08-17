using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GranBazar.Data;
using Microsoft.AspNetCore.Http;
using GranBazar.Models;

namespace GranBazar.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        BazarContext context;

        public UserController(BazarContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            string utenteLoggato = HttpContext.Session.GetString("utenteLoggato");
            var elencoOrdini =
                from x in context.Ordine
                join e in context.Ordine_Prodotto 
                on x.IdOrdine equals e.IdOrdine 
                join f in context.Prodotto
                on e.IdProdotto equals f.IdProdotto
                where x.Email.Equals(utenteLoggato)
                select new VistaProdottoOrdine{
                    IdOrdine = e.IdOrdine,
                    IdProdotto = e.IdProdotto,
                    NomeProdotto = f.NomeProdotto,
                    DescrizioneProdotto = f.DescrizioneProdotto,
                    Quantita = e.Quantita,
                    LinkImmagine = f.LinkImmagine,
                    Prezzo = f.Prezzo,
                    Sconto = f.Sconto,
                    DataOrdine = x.DataOrdine,
                    Stato = x.Stato,
                    DataSpedizione = x.DataSpedizione
                };
            /*
            var listaId = elencoOrdini
                .Select(x => new { x.IdOrdine })
                .Distinct();


            Dictionary <int, List<VistaProdottoOrdine>> listaProdotti = new Dictionary<int, List<VistaProdottoOrdine>>();

            List<VistaProdottoOrdine> listaTmp = new List<VistaProdottoOrdine>();

            int ordId = 0;

            /*
            foreach(var x in listaId.Select((value, i) => new { i, value }))
            {
                listaTmp = new List<VistaProdottoOrdine>();

                foreach (var y in listaId.Select((value, i) => new { i, value }))
                {
                    if(y.value.IdOrdine == x
                }
            }
            /*
                    for (int i=0 ; i<listaId.Count() ;i++)
            {
                listaTmp = new List<VistaProdottoOrdine>();
                for (int j = 0; j< elencoOrdini.Count();j++)
                {
                    if(elencoOrdini.ElementAt(j).IdOrdine == listaId.ElementAt(i).IdOrdine)
                    {
                        listaTmp.Add(elencoOrdini.ElementAt(i));
                        ordId = listaId.ElementAt(j).IdOrdine;
                    }
                }
                listaProdotti.Add(ordId, listaTmp);
            }
            */

      
 
            ViewData["elencoOrdini"] = elencoOrdini;
           // ViewData["numeroOrdini"] = listaId;

            return View();
        }
    }
}