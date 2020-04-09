using ArcoApi.Models;
using System.Collections.Generic;

namespace ArcoApi.Interfaces
{
    public interface IBusinessRilievo
    {
        public IList<Rilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina);

        public string RilievoGetTotaleElementiVista();
    }
}
