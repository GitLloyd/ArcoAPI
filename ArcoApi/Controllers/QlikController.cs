using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ArcoApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ArcoApi.Models;
using Microsoft.Data.SqlClient;

namespace ArcoApi.Controllers
{
    [Route("qlikapi")]
    [ApiController]
    public class QlikController : ControllerBase, IQlikController
    {
        private readonly IBusinessDatiPraticaAudit _businessDatiPraticaAudit;
        private readonly IBusinessAuditOperativoAccesso _businessAuditOperativoAccesso;
        private readonly IBusinessPraticaGruppo _businessPraticaGruppo;
        private readonly IBusinessRilievo _businessRilievo;
        private readonly IBusinessTeam _businessTeam;

        public QlikController(
            IBusinessDatiPraticaAudit businessDatiPraticaAudit,
            IBusinessAuditOperativoAccesso businessAuditOperativoAccesso,
            IBusinessPraticaGruppo businessPraticaGruppo,
            IBusinessRilievo businessRilievo,
            IBusinessTeam businessTeam)
        {
            _businessDatiPraticaAudit = businessDatiPraticaAudit;
            _businessAuditOperativoAccesso = businessAuditOperativoAccesso;
            _businessPraticaGruppo = businessPraticaGruppo;
            _businessRilievo = businessRilievo;
            _businessTeam = businessTeam;
        }


        // Dati Pratica Audit
        [HttpPost]
        [Route("datipraticaaudit")]
        public RisultatoElementiPagina<DatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<DatiPraticaAudit>();

            try
            {
                result.ElementiPagina = _businessDatiPraticaAudit.DatiPraticaAuditGetElementiPagina(numeroElementi, indicePagina);
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
            return _businessDatiPraticaAudit.DatiPraticaAuditGetTotaleElementiVista();
        }


        // Team
        [HttpPost]
        [Route("team")]
        public RisultatoElementiPagina<Team> TeamGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<Team>();

            try
            {
                result.ElementiPagina = _businessTeam.TeamGetElementiPagina(numeroElementi, indicePagina);
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
            return _businessTeam.TeamGetTotaleElementiVista();
        }


        // Audit Operativo Accesso
        [HttpPost]
        [Route("auditoperativoaccesso")]
        public RisultatoElementiPagina<AuditOperativoAccesso> AuditOperativoAccessoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<AuditOperativoAccesso>();

            try
            {
                result.ElementiPagina = _businessAuditOperativoAccesso.AuditOperativoAccessoAuditGetElementiPagina(numeroElementi, indicePagina);
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
            return _businessAuditOperativoAccesso.AuditOperativoAccessoAuditGetTotaleElementiVista();
        }


        //// Domanda Valore
        //[HttpPost]
        //[Route("domandavalore")]
        //public RisultatoElementiPagina<DomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina)
        //{
        //    var result = new RisultatoElementiPagina<DomandaValore>();
            //try
            //{
            //    result.ElementiPagina = _businessPraticaGruppo.DomandaValoreAuditGetElementiPagina(numeroElementi, indicePagina);
            //}
            //catch (ArgumentException argEx)
            //{
            //    Response.StatusCode = 400;
            //    result.CodiceMessaggio = 501;
            //    result.Messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
            //}
            //catch (SqlException sqlEx)
            //{
            //    Response.StatusCode = 500;
            //    result.CodiceMessaggio = 502;
            //    result.Messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
            //}
            //catch (Exception ex)
            //{
            //    Response.StatusCode = 500;
            //    result.CodiceMessaggio = 500;
            //    result.Messaggio = $"Errore generico: {ex.Message}";
        //}

        //return result;
        //}

        //private string DomandaValoreGetTotaleElementiVista()
        //{
        //    throw new NotImplementedException();
        //}


        // Pratica Gruppo
        [HttpPost]
        [Route("praticagruppo")]
        public RisultatoElementiPagina<PraticaGruppo> PraticaGruppoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<PraticaGruppo>();

            try
            {
                result.ElementiPagina = _businessPraticaGruppo.PraticaGruppoAuditGetElementiPagina(numeroElementi, indicePagina);
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
            return _businessPraticaGruppo.PraticaGruppoAuditGetTotaleElementiVista();
        }


        // Rilievo
        [HttpPost]
        [Route("rilievo")]
        public RisultatoElementiPagina<Rilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            var result = new RisultatoElementiPagina<Rilievo>();

            try
            {
                result.ElementiPagina = _businessRilievo.RilievoGetElementiPagina(numeroElementi, indicePagina);
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
            return _businessRilievo.RilievoGetTotaleElementiVista();
        }


        //// Sede
        //[HttpPost]
        //[Route("sede")]
        //public RisultatoElementiPagina<Sede> SedeGetElementiPagina(int numeroElementi, int indicePagina)
        //{
        //    throw new NotImplementedException();
        //}

        //private string SedeGetTotaleElementiVista()
        //{
        //    throw new NotImplementedException();
        //}


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
                //case "ViewQlikDomandaValore":
                //    result.TotaleElementiVista = DomandaValoreGetTotaleElementiVista();
                //    break;
                case "ViewQlikPraticaGruppo":
                    result.TotaleElementiVista = PraticaGruppoGetTotaleElementiVista();
                    break;
                case "ViewQlikRilievo":
                    result.TotaleElementiVista = RilievoGetTotaleElementiVista();
                    break;
                case "ViewQlikTeam":
                    result.TotaleElementiVista = TeamGetTotaleElementiVista();
                    break;
                //case "ViewQlikSede":
                //     result.TotaleElementiVista = SedeGetTotaleElementiVista();
                //     break;
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