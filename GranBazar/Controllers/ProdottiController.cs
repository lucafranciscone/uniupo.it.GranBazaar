using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GranBazar.Data;
using Microsoft.EntityFrameworkCore;
using GranBazar.Dto;
using GranBazar.Models;

namespace GranBazar.Controllers
{

    public class ProdottiController : Controller
    {
        BazarContext context;

        public ProdottiController(BazarContext context) {
            this.context = context;
        }

        public IActionResult SchedaProdotto(int id)
        {
            //recupero il singolo prodotto da mostrare
            var prodotto = 
                from x in context.Prodotto
                where x.IdProdotto == id
                select x;

            return View(prodotto.First());
        }

    }
}
