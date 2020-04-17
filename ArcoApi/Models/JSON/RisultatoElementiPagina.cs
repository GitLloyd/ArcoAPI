using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Models.JSON
{
    public class RisultatoElementiPagina<T>
    {
        public RisultatoRichiesta RisultatoRichiesta { get; set; }

        public IList<T> ElementiPagina { get; set; } = new List<T>();
    }
}
