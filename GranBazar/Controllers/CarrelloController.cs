using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Models;
using Microsoft.AspNetCore.Http;
using GranBazar.Src;
using GranBazar.Data;

namespace GranBazar.Controllers
{
    public class CarrelloController : Controller
    {

        BazarContext Context;
        List<Prodotto> prodottiInCarrello;
        List<int> quantitaPerProdotto;

        public CarrelloController(BazarContext context)
        {
            Context = context;
        }

        public IActionResult Index(int? id)
        {
            var count = 0;
            var tempProdottiInCarrello = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
           
            //su questo IF entriamo solo quando inseriamo elementi
            if (id != null){
                var query =
                    from x in Context.Prodotto
                    where x.IdProdotto == id
                    select x;

                //qua abbiamo già degli elementi nel carrello
                if (tempProdottiInCarrello != null){
                    bool contenuto = false;
                    int posizione = 0;
                    int posizioneContenuto = 0;
                    foreach(var elem in  tempProdottiInCarrello){
                        if(elem.IdProdotto == id){
                            contenuto = true;
                            posizioneContenuto = posizione;
                            break;
                        }
                        posizione++;
                    }

                    //se l'elemento è già presente aggiorno la sua quantità
                    if (contenuto)
                        tempQta[posizioneContenuto]++;
                    else{
                        tempProdottiInCarrello.Add(query.First());
                        tempQta.Add(1);
                    }
                    HttpContext.Session.Set<List<int>>("quantitaPerProdotto", tempQta);
                    HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", tempProdottiInCarrello);
                }
                else //1 volta che entro nel carrello
                {
                    prodottiInCarrello = new List<Prodotto>();
                    quantitaPerProdotto = new List<int>();
                    prodottiInCarrello.Add(query.First());
                    quantitaPerProdotto.Add(1);
                    HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", prodottiInCarrello);
                    HttpContext.Session.Set<List<int>>("quantitaPerProdotto", quantitaPerProdotto);
                }
            }

            foreach (var x in HttpContext.Session.Get<List<int>>("quantitaPerProdotto"))
                count += x;
            HttpContext.Session.SetInt32("numeroElementiInCarrello", count);

            return View();
        }

       //Da rifattorizzare
        public IActionResult RimuoviProdotto(int id)
        {
            var query =
                from x in Context.Prodotto
                where x.IdProdotto == id
                select x;

            var temp = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            HttpContext.Session.Remove("prodottiCarrello");
            var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
            HttpContext.Session.Remove("quantitaPerProdotto");

            int pos = 0;
            foreach (var x in temp)
                if (x.IdProdotto == id)
                    pos = temp.IndexOf(x);

            temp.RemoveAt(pos);
            tempQta.RemoveAt(pos);
            HttpContext.Session.Set<List<Prodotto>>("prodottiCarrello", temp);
            HttpContext.Session.Set<List<int>>("quantitaPerProdotto", tempQta);
            return RedirectToAction("Index");

        }

        public IActionResult AggiornaCarrello(int quantita, int idProdotto)
        {
            var query =
                from x in Context.Prodotto
                where x.IdProdotto == idProdotto
                select x;

            var tempProdottiInCarrello = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");

            var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
            HttpContext.Session.Remove("quantitaPerProdotto");

            int pos = 0;
            foreach (var x in tempProdottiInCarrello)
                if (x.IdProdotto == idProdotto)
                    pos = tempProdottiInCarrello.IndexOf(x);
            tempQta[pos] = quantita;

            HttpContext.Session.Set<List<int>>("quantitaPerProdotto", tempQta);
            return RedirectToAction("Index");
        }

    }
}