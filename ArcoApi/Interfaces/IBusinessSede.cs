using ArcoApi.Models;
using System.Collections.Generic;

namespace ArcoApi.Interfaces
{
    public interface IBusinessSede
    {
        public IList<Sede> SedeGetElementiPagina(int numeroElementi, int indicePagina);

        public string SedeGetTotaleElementiVista();
    }
}
