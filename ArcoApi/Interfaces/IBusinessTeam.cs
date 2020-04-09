using ArcoApi.Models;
using System.Collections.Generic;

namespace ArcoApi.Interfaces
{
    public interface IBusinessTeam
    {
        public IList<Team> TeamGetElementiPagina(int numeroElementi, int indicePagina);

        public string TeamGetTotaleElementiVista();
    }
}
