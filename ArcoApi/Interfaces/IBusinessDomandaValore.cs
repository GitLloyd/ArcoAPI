using ArcoApi.Models;
using System.Collections.Generic;

namespace ArcoApi.Interfaces
{
    public interface IBusinessDomandaValore
    {
        public IList<DomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina);

        public string DomandaValoreGetTotaleElementiVista();
    }
}
