using GranBazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranBazar.Data
{
    public class Query
    {
        public Query() { }

        BazarContext context = new BazarContext();

        public string getRuleByEmail(string email)
        {
            var rule =
                context.Utente
                .Where(x => x.Email.Equals(email))
                .Select(x => new { x.Ruolo });

            return rule.First().Ruolo;
        }


    }
}
