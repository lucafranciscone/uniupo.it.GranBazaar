using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GranBazar.Data;
using Microsoft.Extensions.Logging;
using GranBazar.Models;

namespace GranBazar.Controllers
{
    [Authorize]
    public class ElencoUtentiController : CrudController<BazarContext,string,GranBazar.Models.Utente>
    {
        public ElencoUtentiController(BazarContext context, ILogger<Utente> logger) : base(context, logger)
        {        }

        protected override Microsoft.EntityFrameworkCore.DbSet<Utente> Entities => Context.Utente;

        protected override Func<Utente, string, bool> FilterById => (e, email) => e.Email == email;

        public IActionResult Index()
        {
            return View();
        }
    }
}