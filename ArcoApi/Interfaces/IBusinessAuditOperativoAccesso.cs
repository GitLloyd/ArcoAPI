using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces
{
    public interface IBusinessAuditOperativoAccesso
    {
        public IList<AuditOperativoAccesso> AuditOperativoAccessoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string AuditOperativoAccessoAuditGetTotaleElementiVista();
    }
}
