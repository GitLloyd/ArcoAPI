using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ArcoApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ArcoApi.Models;
using Microsoft.Data.SqlClient;
using ArcoApi.Models.JSON;

namespace ArcoApi.Controllers
{
    [Route("viewqlikapi")]
    [ApiController]
    public class QlikController : ControllerBase, IQlikController
    {
        private readonly IQlikBusiness _qlikBusiness;

        public QlikController(IQlikBusiness qlikBusiness)
        {
            _qlikBusiness = qlikBusiness;

        }


        // Dati Pratica Audit
        [HttpPost]
        [Route("datipraticaaudit")]
        public RisultatoElementiPagina<ViewQlikDatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikDatiPraticaAudit>();

            try
            {
                result.ElementiPagina = _qlikBusiness.DatiPraticaAuditGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string DatiPraticaAuditGetTotaleElementiVista()
        {
            return _qlikBusiness.DatiPraticaAuditGetTotaleElementiVista();
        }


        // Team
        [HttpPost]
        [Route("team")]
        public RisultatoElementiPagina<ViewQlikTeam> TeamGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikTeam>();

            try
            {
                result.ElementiPagina = _qlikBusiness.TeamGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string TeamGetTotaleElementiVista()
        {
            return _qlikBusiness.TeamGetTotaleElementiVista();
        }


        // Audit Operativo Accesso
        [HttpPost]
        [Route("auditoperativoaccesso")]
        public RisultatoElementiPagina<ViewQlikAuditOperativoAccesso> AuditOperativoAccessoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikAuditOperativoAccesso>();

            try
            {
                result.ElementiPagina = _qlikBusiness.AuditOperativoAccessoAuditGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string AuditOperativoAccessoGetTotaleElementiVista()
        {
            return _qlikBusiness.AuditOperativoAccessoAuditGetTotaleElementiVista();
        }


        // Domanda Valore
        [HttpPost]
        [Route("domandavalore")]
        public RisultatoElementiPagina<ViewQlikDomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikDomandaValore>();
            try
            {
                result.ElementiPagina = _qlikBusiness.DomandaValoreGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string DomandaValoreGetTotaleElementiVista()
        {
            return _qlikBusiness.DomandaValoreGetTotaleElementiVista();
        }


        // Pratica Gruppo
        [HttpPost]
        [Route("praticagruppo")]
        public RisultatoElementiPagina<ViewQlikPraticaGruppo> PraticaGruppoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikPraticaGruppo>();

            try
            {
                result.ElementiPagina = _qlikBusiness.PraticaGruppoAuditGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string PraticaGruppoGetTotaleElementiVista()
        {
            return _qlikBusiness.PraticaGruppoAuditGetTotaleElementiVista();
        }


        // Rilievo
        [HttpPost]
        [Route("rilievo")]
        public RisultatoElementiPagina<ViewQlikRilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikRilievo>();

            try
            {
                result.ElementiPagina = _qlikBusiness.RilievoGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string RilievoGetTotaleElementiVista()
        {
            return _qlikBusiness.RilievoGetTotaleElementiVista();
        }


        // Sede
        [HttpPost]
        [Route("sede")]
        public RisultatoElementiPagina<ViewQlikSede> SedeGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<ViewQlikSede>();

            try
            {
                result.ElementiPagina = _qlikBusiness.SedeGetElementiPagina(numeroElementi, indicePagina);
            }
            catch (ArgumentException argEx)
            {
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            }
            catch (SqlException sqlEx)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = $"Errore generico: {ex.Message}";
            }

            return result;
        }

        private string SedeGetTotaleElementiVista()
        {
            return _qlikBusiness.SedeGetTotaleElementiVista();
        }


        // Gestore delle chiamate per il numero degli elementi in una vista
        [HttpPost]
        [Route("totaleelementivista")]
        public RisultatoTotaleElementiVista GetTotaleElementiVista([FromHeader] string vista)
        {
            var result = new RisultatoTotaleElementiVista();

            switch (vista)
            {
                case "ViewQlikDatiPraticaAudit":
                    result.TotaleElementiVista = DatiPraticaAuditGetTotaleElementiVista();
                    break;
                case "ViewQlikAuditOperativoAccesso":
                    result.TotaleElementiVista = AuditOperativoAccessoGetTotaleElementiVista();
                    break;
                case "ViewQlikDomandaValore":
                    result.TotaleElementiVista = DomandaValoreGetTotaleElementiVista();
                    break;
                case "ViewQlikPraticaGruppo":
                    result.TotaleElementiVista = PraticaGruppoGetTotaleElementiVista();
                    break;
                case "ViewQlikRilievo":
                    result.TotaleElementiVista = RilievoGetTotaleElementiVista();
                    break;
                case "ViewQlikTeam":
                    result.TotaleElementiVista = TeamGetTotaleElementiVista();
                    break;
                case "ViewQlikSede":
                    result.TotaleElementiVista = SedeGetTotaleElementiVista();
                    break;
                default:
                    result.RisultatoRichiesta.Messaggio = $"{vista} non corrisponde ad alcuna vista presente nel DB.";
                    result.RisultatoRichiesta.CodiceMessaggio = 501;
                    Response.StatusCode = 400;
                    break;
            };

            return result;
        }
    }
}