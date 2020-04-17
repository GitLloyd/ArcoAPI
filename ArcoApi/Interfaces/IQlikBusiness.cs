using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces
{
    public interface IQlikBusiness
    {
        public IList<Sede> SedeGetElementiPagina(int numeroElementi, int indicePagina);

        public string SedeGetTotaleElementiVista();


        public IList<Team> TeamGetElementiPagina(int numeroElementi, int indicePagina);

        public string TeamGetTotaleElementiVista();


        public IList<PraticaGruppo> PraticaGruppoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string PraticaGruppoAuditGetTotaleElementiVista();


        public IList<DomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina);

        public string DomandaValoreGetTotaleElementiVista();


        public IList<Rilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina);

        public string RilievoGetTotaleElementiVista();


        public IList<DatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string DatiPraticaAuditGetTotaleElementiVista();


        public IList<AuditOperativoAccesso> AuditOperativoAccessoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string AuditOperativoAccessoAuditGetTotaleElementiVista();
    }
}
