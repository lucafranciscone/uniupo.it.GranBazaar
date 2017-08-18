using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using GranBazar.Data;
using GranBazar.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {
        BazarContext Context;
        ILogger Logger;

        public HomeController (BazarContext context, ILogger<ProdottiController> logger)  {
            Context = context;
            Logger = logger;
        }

        public IActionResult Index()
        {
            var query =
                from x in Context.Prodotto
                select x;

            return View(query.ToList());
        }
    }
}