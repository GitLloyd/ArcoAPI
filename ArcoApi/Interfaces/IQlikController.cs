using ArcoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Interfaces
{
    interface IQlikController
    {
        // Gestore delle chiamate per il numero totale di elementi in una vista
        RisultatoTotaleElementiVista GetTotaleElementiVista(string vista);

        // Dati Pratica Audit
        RisultatoElementiPagina<DatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina);

        // AuditOperativoAccesso
        RisultatoElementiPagina<AuditOperativoAccesso> AuditOperativoAccessoGetElementiPagina(int numeroElementi, int indicePagina);

        // DomandaValore
        //RisultatoElementiPagina<DomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina);

        // PraticaGruppo
        RisultatoElementiPagina<PraticaGruppo> PraticaGruppoGetElementiPagina(int numeroElementi, int indicePagina);

        // Rilievo
        RisultatoElementiPagina<Rilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina);

        // Team
        RisultatoElementiPagina<Team> TeamGetElementiPagina(int numeroElementi, int indicePagina);

        // Sede
        //RisultatoElementiPagina<Sede> SedeGetElementiPagina(int numeroElementi, int indicePagina);
    }
}
