using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GranBazar.Models;
using GranBazar.Data;
using Microsoft.AspNetCore.Http;
using GranBazar.Src;

namespace GranBazar.Controllers
{
    public class AccountController : Controller
    {

        readonly UserManager<IdentityUser> userManager;
        readonly SignInManager<IdentityUser> signInManager;
        readonly BazarContext context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, BazarContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repassword)
        {
            if (password != repassword)
            {
                ModelState.AddModelError(string.Empty, "Password don't match");
                return View();
            }

            var newUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var userCreationResult = await userManager.CreateAsync(newUser, password);

            context.Utente.Add(new Utente
            {
                Email = email,
                Psw = password,
                Ruolo = "User"
            });

            context.SaveChanges();

            if (!userCreationResult.Succeeded)
            {
                foreach (var error in userCreationResult.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            return Content("User created");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe, string url)
        {
            try
            {
                var path = url;

                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View();
                }
                var passwordSignInResult = await signInManager.PasswordSignInAsync(user, password,
                    isPersistent: rememberMe, lockoutOnFailure: false);
                if (!passwordSignInResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login");
                    return View();
                }

                var utente =
                     from x in context.Utente
                     where x.Email.Equals(email)
                     select x;

                HttpContext.Session.Set<Utente>("utenteLoggato",(Utente) utente.Single());

                return Redirect(url);

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();            //toglie tutti gli oggetti in sessione
            return Redirect("~/");
        }

        public IActionResult ElencoUtenti(string email, string ruolo)
        {
            if (email != null && ruolo != null && (ruolo.Equals("Admin") || ruolo.Equals("User")))
            {
                var utenteDaAggiornare =
                     from user in context.Utente
                     where user.Email.Equals(email)
                     select user;

                Utente u = utenteDaAggiornare.SingleOrDefault();
                u.Ruolo = ruolo;
                context.SaveChanges();
            }

            var utente =
                  from user in context.Utente
                  select user;
            return View(utente.ToList());
        }

        /*
        * da sistemare o ottimizzare questo pezzo, successivamente traformare la vista in tabella filtrabile
        * */
        public IActionResult CatalogoProdotti(int? idProdotto, bool? stato, string prezzo, int sconto)
        {
            //aggiorno il prezzo
            if (prezzo != null && idProdotto != null && Decimal.Parse(prezzo) > 0)
            {
                var prodottoDaAggiornare =
                    from prod in context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;

                Prodotto p = prodottoDaAggiornare.First();
                p.Prezzo = Decimal.Parse(prezzo);
                context.SaveChanges();
            }


            //CASO IN CUI DEVO AGGIORNARE
            if (idProdotto != null && stato != null)
            {
                Boolean update = false;
                if (stato == true)
                {
                    update = true;
                }
                var prodottoDaAggiornare =
                    from prod in context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;

                Prodotto p = prodottoDaAggiornare.SingleOrDefault();
                p.Disponibile = update;
                context.SaveChanges();

            }

            if (sconto != null && sconto > 0 && idProdotto != null)
            {
                //recupero il prodotto da aggiornare
                var prodottoDaAggiornare =
                    from prod in context.Prodotto
                    where prod.IdProdotto == idProdotto
                    select prod;
                Prodotto p = prodottoDaAggiornare.SingleOrDefault();
                p.Sconto = (byte)sconto;
                context.SaveChanges();
            }


            var catalogoProdotti =
            from prod in context.Prodotto
            select prod;
            return View(catalogoProdotti.ToList());


        }

        /*
        * da sistemare o ottimizzare questo pezzo, successivamente traformare la vista in tabella filtrabile
        * */
        public IActionResult ElencoOrdini(int? idOrdine, string stato)
        {
            if (idOrdine != null && stato != null)
                if (stato.Equals("Processato"))
                {
                    var ordineDaAggiornare =
                        from ord in context.Ordine
                        where ord.IdOrdine == idOrdine
                        select ord;

                    Ordine p = ordineDaAggiornare.First();
                    p.Stato = stato;
                    p.DataSpedizione = DateTime.Now;
                    context.SaveChanges();
                }


            List<VistaProdottoOrdine> vista = new List<VistaProdottoOrdine>();
            VistaProdottoOrdine tmpAdd;
            var idProdottiAcquistatiOrdinatiUltimo =
              from op in context.Ordine_Prodotto
              join p in context.Prodotto on op.IdProdotto equals p.IdProdotto
              join o in context.Ordine on op.IdOrdine equals o.IdOrdine
              select new
              {
                  IdOrdine = op.IdOrdine,
                  DataOrdine = o.DataOrdine,
                  Stato = o.Stato,//sent processed
                  DataSpedizione = o.DataSpedizione,
                  Quantita = op.Quantita,
                  IdProdotto = p.IdProdotto,
                  NomeProdotto = p.NomeProdotto,
                  DescrizioneProdotto = p.DescrizioneProdotto,
                  Prezzo = p.Prezzo,
                  Sconto = p.Sconto,
                  Email = o.Email,

              };

            foreach (var t in idProdottiAcquistatiOrdinatiUltimo)
            {
                tmpAdd = new VistaProdottoOrdine();
                tmpAdd.IdOrdine = t.IdOrdine;
                tmpAdd.DataOrdine = t.DataOrdine;
                tmpAdd.DataSpedizione = t.DataSpedizione;
                tmpAdd.Quantita = t.Quantita;
                tmpAdd.IdProdotto = t.IdProdotto;
                tmpAdd.NomeProdotto = t.NomeProdotto;
                tmpAdd.DescrizioneProdotto = t.DescrizioneProdotto;
                tmpAdd.Prezzo = t.Prezzo;
                tmpAdd.Sconto = t.Sconto;
                tmpAdd.Email = t.Email;
                tmpAdd.Stato = t.Stato;
                vista.Add(tmpAdd);
            }
            return View(vista);

        }

        public IActionResult AreaRiservataUser()
        {
            var utenteLoggato = HttpContext.Session.Get<Utente>("utenteLoggato");

            var elencoOrdini =
                from x in context.Ordine
                join e in context.Ordine_Prodotto
                on x.IdOrdine equals e.IdOrdine
                join f in context.Prodotto
                on e.IdProdotto equals f.IdProdotto
                where x.Email.Equals(utenteLoggato.Email)
                select new VistaProdottoOrdine
                {
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


            Dictionary<int, List<VistaProdottoOrdine>> elencoIdOrdiniConAssociatoElencoProdotti = new Dictionary<int, List<VistaProdottoOrdine>>();

            //dichiaro una lista temporanea che conterrà l'elenco prodotti per un singolo id ordine
            List<VistaProdottoOrdine> listaTmp = new List<VistaProdottoOrdine>();

            int ordineIdPerHash = 0;

            for (int i = 0; i < elencoIdInFormatoLista.Count(); i++)
            {
                listaTmp = new List<VistaProdottoOrdine>();
                for (int j = 0; j < elencoOrdiniInFormatoLista.Count(); j++)
                {
                    if (elencoOrdiniInFormatoLista.ElementAt(j).IdOrdine == elencoIdInFormatoLista.ElementAt(i).IdOrdine)
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