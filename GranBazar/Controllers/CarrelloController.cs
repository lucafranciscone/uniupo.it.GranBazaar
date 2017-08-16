using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Models;
using Microsoft.AspNetCore.Http;
using GranBazar.Src;

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


        //dobbiamo mettere le cose in sessione, così non funziona
        public IActionResult Index(int? id)
        {
            if (id != null)// se inserisco il primo elemento
            {
                //dall'id recupero l'elemento
                var query =
                    from x in Context.Prodotto
                    where x.IdProdotto == id
                    select x;
       
                var tempProdottiInCarrello = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
                HttpContext.Session.Remove("prodottiCarrello");
                var tempQta = HttpContext.Session.Get<List<int>>("quantitaPerProdotto");
                HttpContext.Session.Remove("quantitaPerProdotto");

                if (tempProdottiInCarrello != null)
                {
                    bool contenuto = false;
                    int posizione = 0;
                    int posizioneContenuto = 0;
                    foreach(var elem in  tempProdottiInCarrello)// è presente e ho l'indice
                    {
                        if(elem.IdProdotto == id)
                        {
                            contenuto = true;
                            posizioneContenuto = posizione;
                            break;
                        }
                        posizione++;
                    }

                    //prima controllare se è presente 

                    //questa parte ricerca se il prodotto è già presente, se si aggiorno quantita con +1
                   // Prodotto acazzo = (Prodotto)query.First();
                    if (contenuto == true)
                    {//1) Controllo se il prodotto è contenuto --> aggiorno quantità
                        
                        //int pos = 0;//2) trovo l indice del prodotto
                        //f//oreach (var x in tempProdottiInCarrello)
                           // if (x.IdProdotto == id)
                              //  pos = tempProdottiInCarrello.IndexOf(x);
                        //3) aggiorno il vettore delle quantità
                        tempQta[posizioneContenuto] ++;
                    }
                    else
                    {
                    
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
           // HttpContext.Session.SetInt32("id",id);

            //var t = HttpContext.Session.Get<List<Prodotto>>("prodottiCarrello");
            //System.Console.WriteLine($"Nel carrello ci sono: {t.First().NomeProdotto}");
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