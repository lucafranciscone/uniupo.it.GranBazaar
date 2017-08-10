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
    [Authorize]
    public class ProdottiController : CrudController<BazarContext, int, Prodotto>
    {

        public ProdottiController(BazarContext context, ILogger<ProdottiController> logger) : base(context, logger) { }

        protected override DbSet<Prodotto> Entities => Context.Prodotto;

        protected override Func<Prodotto, int, bool> FilterById => (e, id) => e.IdProdotto == id;

        public override Task<IActionResult> Delete(int IdProdotto) =>base.Delete(IdProdotto);


    }
}
