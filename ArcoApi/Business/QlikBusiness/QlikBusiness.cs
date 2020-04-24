using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Models;
using ArcoApi.Repositories;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Business.QlikBusiness
{
    public class QlikBusiness : IQlikBusiness
    {
        private readonly QlikDbContext _qlikDbContext;

        public QlikBusiness(QlikDbContext qlikDbContext)
        {
            _qlikDbContext = qlikDbContext;
        }

        #region Team
        public IList<ViewQlikTeam> TeamGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(TeamGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikTeam> result = _qlikDbContext.ViewQlikTeam
                                                           .OrderByDescending(dati => dati.IdAuditOperativo)
                                                           .Skip(elementiDaSaltare)
                                                           .Take(numeroElementi)
                                                           .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string TeamGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikTeam.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion

        #region Rilievo
        public IList<ViewQlikRilievo> RilievoGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(RilievoGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi; 
                
                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikRilievo> result = _qlikDbContext.ViewQlikRilievo
                                                              .OrderByDescending(dati => dati.IdAuditOperativo)
                                                              .Skip(elementiDaSaltare)
                                                              .Take(numeroElementi)
                                                              .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RilievoGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikRilievo.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion

        #region Sede
        public IList<ViewQlikSede> SedeGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(SedeGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikSede> result = _qlikDbContext.ViewQlikSede
                                                           .OrderByDescending(dati => dati.CodiceSede)
                                                           .Skip(elementiDaSaltare)
                                                           .Take(numeroElementi)
                                                           .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SedeGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikSede.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion

        #region PraticaGruppo
        public IList<ViewQlikPraticaGruppo> PraticaGruppoAuditGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(PraticaGruppoAuditGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikPraticaGruppo> result = _qlikDbContext.ViewQlikPraticaGruppo
                                                                    .OrderByDescending(dati => dati.IdAuditOperativo)
                                                                    .Skip(elementiDaSaltare)
                                                                    .Take(numeroElementi)
                                                                    .ToList();

                Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string PraticaGruppoAuditGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikPraticaGruppo.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion

        #region DomandaValore
        public IList<ViewQlikDomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(DomandaValoreGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikDomandaValore> result = _qlikDbContext.ViewQlikDomandaValore
                                                                    .OrderByDescending(dati => dati.IdAuditOperativo)
                                                                    .Skip(elementiDaSaltare)
                                                                    .Take(numeroElementi)
                                                                    .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DomandaValoreGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikDomandaValore.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }

        #endregion

        #region DatiPraticaAudit
        public IList<ViewQlikDatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(DatiPraticaAuditGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikDatiPraticaAudit> result = _qlikDbContext.ViewQlikDatiPraticaAudit
                                                                       .OrderByDescending(dati => dati.IdAuditOperativo)
                                                                       .Skip(elementiDaSaltare)
                                                                       .Take(numeroElementi)
                                                                       .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DatiPraticaAuditGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikDatiPraticaAudit.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion

        #region AuditOperativoAccesso
        public IList<ViewQlikAuditOperativoAccesso> AuditOperativoAccessoAuditGetElementiPagina(int numeroElementi, int indicePagina)
        {
            try
            {
                if (numeroElementi < 1)
                {
                    throw new ArgumentException("Il numero di elementi da reperire deve essere maggiore di 0.");
                }

                int totaleElementi = Convert.ToInt32(DatiPraticaAuditGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;

                Log.Information($"La vista contiene un totale di {totaleElementi} elementi per {totalePagine} pagine.");

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                Log.Information("Chiamata al database per l'ottenimento degli elementi richiesti...");

                IList<ViewQlikAuditOperativoAccesso> result = _qlikDbContext.ViewQlikAuditOperativoAccesso
                                                                            .OrderByDescending(dati => dati.IdAuditOperativo)
                                                                            .Skip(elementiDaSaltare)
                                                                            .Take(numeroElementi)
                                                                            .ToList();

                Log.Information("Chiamata andata a buon fine. Restituzione dei risultati...");

                return result;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AuditOperativoAccessoAuditGetTotaleElementiVista()
        {
            Log.Information("Chiamata al database per il conteggio degli elementi...");

            int count = _qlikDbContext.ViewQlikAuditOperativoAccesso.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion
    }
}
