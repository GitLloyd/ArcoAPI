using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces.QlikBusiness
{
    public interface IQlikBusiness
    {
        public IList<ViewQlikSede> SedeGetElementiPagina(int numeroElementi, int indicePagina);

        public string SedeGetTotaleElementiVista();


        public IList<ViewQlikTeam> TeamGetElementiPagina(int numeroElementi, int indicePagina);

        public string TeamGetTotaleElementiVista();


        public IList<ViewQlikPraticaGruppo> PraticaGruppoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string PraticaGruppoAuditGetTotaleElementiVista();


        public IList<ViewQlikDomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina);

        public string DomandaValoreGetTotaleElementiVista();


        public IList<ViewQlikRilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina);

        public string RilievoGetTotaleElementiVista();


        public IList<ViewQlikDatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string DatiPraticaAuditGetTotaleElementiVista();


        public IList<ViewQlikAuditOperativoAccesso> AuditOperativoAccessoAuditGetElementiPagina(int numeroElementi, int indicePagina);

        public string AuditOperativoAccessoAuditGetTotaleElementiVista();
    }
}
