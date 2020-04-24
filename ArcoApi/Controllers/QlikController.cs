using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

using ArcoApi.Interfaces;
using ArcoApi.Models;
using ArcoApi.Models.JSON;
using ArcoApi.Interfaces.QlikBusiness;

using Serilog;

namespace ArcoApi.Controllers
{
    [Authorize]
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikDatiPraticaAudit alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikDatiPraticaAudit>();

            try
            {
                result.ElementiPagina = _qlikBusiness.DatiPraticaAuditGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikTeam alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikTeam>();

            try
            {
                result.ElementiPagina = _qlikBusiness.TeamGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikAuditOperativoAccesso alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikAuditOperativoAccesso>();

            try
            {
                result.ElementiPagina = _qlikBusiness.AuditOperativoAccessoAuditGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di QlikDomandaValore alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikDomandaValore>();

            try
            {
                result.ElementiPagina = _qlikBusiness.DomandaValoreGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikPraticaGruppo alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikPraticaGruppo>();

            try
            {
                result.ElementiPagina = _qlikBusiness.PraticaGruppoAuditGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikRilievo alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikRilievo>();

            try
            {
                result.ElementiPagina = _qlikBusiness.RilievoGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di {numeroElementi} elementi di ViewQlikSede alla pagina {indicePagina} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

            var result = new RisultatoElementiPagina<ViewQlikSede>();

            try
            {
                result.ElementiPagina = _qlikBusiness.SedeGetElementiPagina(numeroElementi, indicePagina);
                Log.Information("Risultati ottenuti. Invio della risposta al client.");
            }
            catch (ArgumentException argEx)
            {
                string messaggio = $"Errore nei parametri ricevuti: {argEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 400;
                result.RisultatoRichiesta.CodiceMessaggio = 501;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (SqlException sqlEx)
            {
                string messaggio = $"Errore nel generare SQL: {sqlEx.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 502;
                result.RisultatoRichiesta.Messaggio = messaggio;
            }
            catch (Exception ex)
            {
                string messaggio = $"Errore generico: {ex.Message}";
                Log.Error(messaggio);
                Response.StatusCode = 500;
                result.RisultatoRichiesta.CodiceMessaggio = 500;
                result.RisultatoRichiesta.Messaggio = messaggio;
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
        public RisultatoTotaleElementiVista GetTotaleElementiVista(string vista)
        {
            bool validUserAgent = Request.Headers.TryGetValue("User-Agent", out var userAgent);
            Log.Information($"Ricevuta richiesta di numero totale elementi di {vista} da \"{(validUserAgent ? userAgent.ToString() : "User-Agent non trovato")}\".");

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
                    string messaggio = $"{vista} non corrisponde ad alcuna vista presente nel DB.";
                    Log.Warning(messaggio);
                    result.RisultatoRichiesta.Messaggio = messaggio;
                    result.RisultatoRichiesta.CodiceMessaggio = 501;
                    Response.StatusCode = 400;
                    break;
            };

            Log.Information("Risultati ottenuti. Invio della risposta al client.");

            return result;
        }
    }
}