using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranBazar.Data
{
    public class DataSourceResult
    {
        public int Total { get; set; }
        public IEnumerable Data { get; set; }
    
    }
}
