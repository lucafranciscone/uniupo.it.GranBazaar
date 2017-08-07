﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranBazar.Src
{
    public static class Extensions
    {
        public static SelectList ToSelectList<T>(this DbSet<T> entities, string dataValueField, string dataTextField) 
            where T : class => new SelectList(entities.ToList(), dataValueField, dataTextField);

        public static string ToJson(this SelectList selectList)
        {
            var q =
                from i in selectList.Cast<SelectListItem>()
                select new
                {
                    value = i.Value,
                    text = i.Text
                };
            return JsonConvert.SerializeObject(q);
        }
    }

}
