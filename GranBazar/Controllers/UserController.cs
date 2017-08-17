using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GranBazar.Data;

namespace GranBazar.Controllers
{

    public class UserController : Controller
    {
        BazarContext context;

        public UserController(BazarContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var query =
                from x in context.Ordine
                select x;
            TempData["numeroOrdini"] = query.Count();
            return View();
        }
    }
}