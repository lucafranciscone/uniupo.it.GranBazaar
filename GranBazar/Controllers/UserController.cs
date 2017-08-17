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

            var elencoId = elencoOrdini
                .Select(x => new { x.IdOrdine })
                .Distinct();

            //converto elencoOrdini in lista
            var elencoOrdiniInFormatoLista = elencoOrdini.ToList();

            //converto listaId in lista
            var elencoIdInFormatoLista = elencoId.ToList();


            Dictionary <int, List<VistaProdottoOrdine>> elencoIdOrdiniConAssociatoElencoProdotti = new Dictionary<int, List<VistaProdottoOrdine>>();

            //dichiaro una lista temporanea che conterrà l'elenco prodotti per un singolo id ordine
            List<VistaProdottoOrdine> listaTmp = new List<VistaProdottoOrdine>();

            int ordineIdPerHash = 0;

            for (int i=0 ; i<elencoIdInFormatoLista.Count() ;i++)
            {
                listaTmp = new List<VistaProdottoOrdine>();
                for (int j = 0; j< elencoOrdiniInFormatoLista.Count();j++)
                {
                    if(elencoOrdiniInFormatoLista.ElementAt(j).IdOrdine == elencoIdInFormatoLista.ElementAt(i).IdOrdine)
                    {
                        listaTmp.Add(elencoOrdiniInFormatoLista.ElementAt(j));
                        ordineIdPerHash = elencoIdInFormatoLista.ElementAt(i).IdOrdine;
                    }
                }
                elencoIdOrdiniConAssociatoElencoProdotti.Add(ordineIdPerHash, listaTmp);
            }

            ViewData["elencoOrdini"] = elencoIdOrdiniConAssociatoElencoProdotti;

            return View();
        }
    }
}