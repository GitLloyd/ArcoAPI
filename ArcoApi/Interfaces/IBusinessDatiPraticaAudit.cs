using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces
{
    public interface IBusinessDatiPraticaAudit
    {
        public IList<DatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string DatiPraticaAuditGetTotaleElementiVista();
    }
}
