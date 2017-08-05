using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GranBazar.Controllers
{
    public class HomeController : Controller
    {
        /*
        public string Index()
        {
            var html = new StringBuilder();
            html.Append("<html>");
            html.Append("<body>");
            html.Append("<h1>HTML</h1>");
            html.Append("</body>");
            html.Append("</html>");
            return html.ToString();

        }*/

        public IActionResult Index() => View();

        public IActionResult Prodotti() => View();


    }
}