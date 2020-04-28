using ArcoApi.Cryptography;
using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Models;
using ArcoApi.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Business.QlikBusiness
{
    public class QlikBusiness : IQlikBusiness
    {
        private readonly QlikDbContext qlikDbContext;
        private readonly IConfiguration config;

        public QlikBusiness(QlikDbContext _qlikDbContext, IConfiguration configuration)
        {
            qlikDbContext = _qlikDbContext;
            config = configuration;
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

                IList<ViewQlikTeam> result = qlikDbContext.ViewQlikTeam
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

            int count = qlikDbContext.ViewQlikTeam.Count();
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

                IList<ViewQlikRilievo> result = qlikDbContext.ViewQlikRilievo
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

            int count = qlikDbContext.ViewQlikRilievo.Count();
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

                IList<ViewQlikSede> result = qlikDbContext.ViewQlikSede
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

            int count = qlikDbContext.ViewQlikSede.Count();
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

                IList<ViewQlikPraticaGruppo> result = qlikDbContext.ViewQlikPraticaGruppo
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

            int count = qlikDbContext.ViewQlikPraticaGruppo.Count();
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

                IList<ViewQlikDomandaValore> result = qlikDbContext.ViewQlikDomandaValore
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

            int count = qlikDbContext.ViewQlikDomandaValore.Count();
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

                List<ViewQlikDatiPraticaAudit> result = qlikDbContext.ViewQlikDatiPraticaAudit
                                                                     .OrderByDescending(dati => dati.Audit)
                                                                     .Skip(elementiDaSaltare)
                                                                     .Take(numeroElementi)
                                                                     .Where(item => item.Infortunio != null)
                                                                     .ToList();

                string richiestaDecifratura = config.GetSection("RichiestaDecifratura").Value;
                if (Convert.ToBoolean(richiestaDecifratura))
                {
                    Log.Information("Richiesta decifratura dei dati...");
                    result.ForEach(item =>
                    {
                        if (item.NumeroCaso != null)          item.NumeroCaso = QlikCryptography.DecryptString(item.NumeroCaso);
                        if (item.CodiceSede != null)          item.CodiceSede = QlikCryptography.DecryptString(item.CodiceSede);
                        if (item.Infortunio != null)          item.Infortunio = QlikCryptography.DecryptString(item.Infortunio);
                        if (item.Sede != null)                item.Sede = QlikCryptography.DecryptString(item.Sede);
                        if (item.Pratica != null)             item.Pratica = QlikCryptography.DecryptString(item.Pratica);
                        if (item.Tipologia != null)           item.Tipologia = QlikCryptography.DecryptString(item.Tipologia);
                        if (item.NumeroPratica != null)       item.NumeroPratica = QlikCryptography.DecryptString(item.NumeroPratica);
                        if (item.NumeroProgrProgetto != null) item.NumeroProgrProgetto = QlikCryptography.DecryptString(item.NumeroProgrProgetto);
                        if (item.RagioneSociale != null)      item.RagioneSociale = QlikCryptography.DecryptString(item.RagioneSociale);
                        if (item.CodiceDitta != null)         item.CodiceDitta = QlikCryptography.DecryptString(item.CodiceDitta);
                        if (item.Ditta != null)               item.Ditta = QlikCryptography.DecryptString(item.Ditta);
                        if (item.Matricola != null)           item.Matricola = QlikCryptography.DecryptString(item.Matricola);
                        if (item.NumeroCasoFornitura != null) item.NumeroCasoFornitura = QlikCryptography.DecryptString(item.NumeroCasoFornitura);
                        if (item.NumeroDomanda != null)       item.NumeroDomanda = QlikCryptography.DecryptString(item.NumeroDomanda);
                    });
                    Log.Information("Dati decifrati.");
                }                              

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

            int count = qlikDbContext.ViewQlikDatiPraticaAudit.Count();
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

                IList<ViewQlikAuditOperativoAccesso> result = qlikDbContext.ViewQlikAuditOperativoAccesso
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

            int count = qlikDbContext.ViewQlikAuditOperativoAccesso.Count();
            string totaleElementi = count.ToString();

            Log.Information($"Trovati {totaleElementi} elementi. Restituzione dell'informazione...");

            return count.ToString();
        }
        #endregion
    }
}
