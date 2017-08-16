
using GranBazar.Data;
using GranBazar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranBazar.Src
{
    public class Query
    {
        protected BazarContext context;
        
        public Query(BazarContext context)
        {
            context = context;
        }

        public string getRuleByEmail(string email)
        {
            var query =
                from x in context.Utente
                where x.Email.Equals(email)
                select x.Ruolo;
            return query.First().ToString(); ;
        }
    }
}
