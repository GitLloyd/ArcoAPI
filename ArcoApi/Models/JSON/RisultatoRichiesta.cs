using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Models.JSON
{
    public class RisultatoRichiesta
    {
        public int CodiceMessaggio { get; set; } = 200;

        public string Messaggio { get; set; } = "OK";
    }
}
