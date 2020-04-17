using ArcoApi.Models;
using ArcoApi.Models.JSON;
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
        RisultatoElementiPagina<ViewQlikDatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina);

        // AuditOperativoAccesso
        RisultatoElementiPagina<ViewQlikAuditOperativoAccesso> AuditOperativoAccessoGetElementiPagina(int numeroElementi, int indicePagina);

        // DomandaValore
        RisultatoElementiPagina<ViewQlikDomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina);

        // PraticaGruppo
        RisultatoElementiPagina<ViewQlikPraticaGruppo> PraticaGruppoGetElementiPagina(int numeroElementi, int indicePagina);

        // Rilievo
        RisultatoElementiPagina<ViewQlikRilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina);

        // Team
        RisultatoElementiPagina<ViewQlikTeam> TeamGetElementiPagina(int numeroElementi, int indicePagina);

        // Sede
        RisultatoElementiPagina<ViewQlikSede> SedeGetElementiPagina(int numeroElementi, int indicePagina);
    }
}
