using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces
{
    public interface IBusinessPraticaGruppo
    {
        public IList<PraticaGruppo> PraticaGruppoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string PraticaGruppoAuditGetTotaleElementiVista();
    }
}