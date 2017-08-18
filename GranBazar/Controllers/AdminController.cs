using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GranBazar.Data;
using GranBazar.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GranBazar.Controllers
{
    [Authorize]
    public class AdminController : CrudController<BazarContext, string, Utente>
    {
        public AdminController(BazarContext context, ILogger<AdminController> logger) : base(context, logger) {}

        protected override DbSet<Utente> Entities => Context.Utente;

        protected override Func<Utente, string, bool> FilterById => (e, id) => e.Email == id;


    }
}