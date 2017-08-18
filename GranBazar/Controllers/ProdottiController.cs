using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Data;
using Microsoft.EntityFrameworkCore;
using GranBazar.Dto;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using GranBazar.Models;
using Microsoft.AspNetCore.Authorization;


namespace GranBazar.Controllers
{

    public class ProdottiController : CrudController<BazarContext, int, Prodotto>
    {
        BazarContext Context;
        public ProdottiController(BazarContext context, ILogger<ProdottiController> logger) : base(context, logger) {
            Context = context;
        }

        protected override DbSet<Prodotto> Entities => Context.Prodotto;

        protected override Func<Prodotto, int, bool> FilterById => (e, id) => e.IdProdotto == id;

        public IActionResult SchedaProdotto(int id)
        {
            var query = 
                from x in Context.Prodotto
                where x.IdProdotto == id
                select x;

            return View(query.First());
        }

        [Authorize]
        public IActionResult CatalogoProdotti() => View();
    }
}
