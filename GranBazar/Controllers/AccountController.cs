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
using Microsoft.AspNetCore.Authorization;

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
                ModelState.AddModelError("errore", "Attenzione, reinserire la stessa password.");
                TempData["errore"] = "errore";
                return View();
            }

            var newUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var userCreationResult = await userManager.CreateAsync(newUser, password);

            var utente =
                     from x in context.Utente
                     where x.Email.Equals(email)
                     select x;
            if(utente.Count() > 0)
                if(utente.First().Email.Equals(email))
                {
                    ModelState.AddModelError("errore", "Attenzione, email già presente nel sistema.");
                    TempData["errore"] = "errore";
                    return View();
                }

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

     
            TempData["successo"] = "successo";
            return View();
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
                    ModelState.AddModelError(string.Empty, "Email non corretta. Riprova.");
                    TempData["errore"] = "errore";
                    return View();
                }
                var passwordSignInResult = await signInManager.PasswordSignInAsync(user, password,
                    isPersistent: rememberMe, lockoutOnFailure: false);
                if (!passwordSignInResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Password non corretta. Riprova.");
                    TempData["errore"] = "errore";
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
            HttpContext.Session.Clear();            
            return Redirect("~/");
        }

        [Authorize]
        public IActionResult ElencoUtenti(string email, string ruolo)
        {
            if ("Admin".Equals(ruolo) || "User".Equals(ruolo))
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

        [Authorize]
        public IActionResult CatalogoProdotti(int? idProdotto,string nome, string descrizione, bool? stato, string prezzo, int sconto)
        {
            //Controllo se non è una modifica
            if(idProdotto  == null || idProdotto<=0     || 
               nome        == null || nome==""          ||
               descrizione == null || descrizione == "" ||
               stato       == null ||
               prezzo      == null || prezzo == ""      || Decimal.Parse(prezzo) <= 0)
            {
                var catalogoProdotti =
                from prod in context.Prodotto
                select prod;
                return View(catalogoProdotti.ToList());
            }

            var prodottoDaAggiornare =
                from prod in context.Prodotto
                where prod.IdProdotto == idProdotto
                select prod;

            if (prodottoDaAggiornare.Count() == 0) return RedirectToAction("CatalogoProdotti");

            Prodotto p = prodottoDaAggiornare.First();
            p.NomeProdotto = nome;
            p.DescrizioneProdotto = descrizione;
            p.Disponibile = stato.Equals(true);
            p.Prezzo = Decimal.Parse(prezzo);
            p.Sconto = (byte)sconto;
            context.SaveChanges();
            
            return RedirectToAction("CatalogoProdotti");
        }

        [Authorize]
        public IActionResult ElencoOrdini(int? idOrdine, string stato)
        {
            //Aggiorna lo stato solo se viene selezionato "Processato"
            if (idOrdine != null && "Processato".Equals(stato))
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

            var vista =
              from op in context.Ordine_Prodotto
              join p in context.Prodotto on op.IdProdotto equals p.IdProdotto
              join o in context.Ordine on op.IdOrdine equals o.IdOrdine
              select new VistaProdottoOrdine
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
            return View(vista.ToList());

        }

        [Authorize]
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

            //filtriamo per IdOrdine in quanto è autoincrementale e corrisponde ad un ordine temporale
            elencoOrdini = elencoOrdini.OrderByDescending(x => x.IdOrdine);
                
            var elencoId = elencoOrdini
                .Select(x => new { x.IdOrdine })
                .Distinct()
                .ToList();

            //converto elencoOrdini in lista
            var elencoOrdiniInFormatoLista = elencoOrdini.ToList();

            Dictionary<int, List<VistaProdottoOrdine>> elencoIdOrdiniConAssociatoElencoProdotti = new Dictionary<int, List<VistaProdottoOrdine>>();

            //dichiaro una lista temporanea che conterrà l'elenco prodotti per un singolo id ordine
            List<VistaProdottoOrdine> listaTmp = new List<VistaProdottoOrdine>();

            for (int i = 0; i < elencoId.Count(); i++)
            {
                listaTmp = new List<VistaProdottoOrdine>();
                for (int j = 0; j < elencoOrdiniInFormatoLista.Count(); j++)
                {
                    if (elencoOrdiniInFormatoLista.ElementAt(j).IdOrdine == elencoId.ElementAt(i).IdOrdine)
                    {
                        listaTmp.Add(elencoOrdiniInFormatoLista.ElementAt(j));
                    }
                }
                elencoIdOrdiniConAssociatoElencoProdotti.Add(elencoId.ElementAt(i).IdOrdine, listaTmp);
            }

            ViewData["elencoOrdini"] = elencoIdOrdiniConAssociatoElencoProdotti;

            return View();
        }

    }
}