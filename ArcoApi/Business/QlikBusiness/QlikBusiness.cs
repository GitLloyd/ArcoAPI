using ArcoApi.Interfaces;
using ArcoApi.Interfaces.QlikBusiness;
using ArcoApi.Models;
using ArcoApi.Repository;
using Microsoft.Data.SqlClient;
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikTeam> result = _qlikDbContext.ViewQlikTeam
                                       .OrderByDescending(dati => dati.IdAuditOperativo)
                                       .Skip(elementiDaSaltare)
                                       .Take(numeroElementi)
                                       .ToList();
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
            int count = _qlikDbContext.ViewQlikDatiPraticaAudit.Count();
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikRilievo> result = _qlikDbContext.ViewQlikRilievo
                                          .OrderByDescending(dati => dati.IdAuditOperativo)
                                          .Skip(elementiDaSaltare)
                                          .Take(numeroElementi)
                                          .ToList();
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
            int count = _qlikDbContext.ViewQlikRilievo.Count();
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikSede> result = _qlikDbContext.ViewQlikSede
                                       .OrderByDescending(dati => dati.CodiceSede)
                                       .Skip(elementiDaSaltare)
                                       .Take(numeroElementi)
                                       .ToList();
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
            int count = _qlikDbContext.ViewQlikSede.Count();
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikPraticaGruppo> result = _qlikDbContext.ViewQlikPraticaGruppo
                                                .OrderByDescending(dati => dati.IdAuditOperativo)
                                                .Skip(elementiDaSaltare)
                                                .Take(numeroElementi)
                                                .ToList();
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
            int count = _qlikDbContext.ViewQlikPraticaGruppo.Count();
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikDomandaValore> result = _qlikDbContext.ViewQlikDomandaValore
                                                .OrderByDescending(dati => dati.IdAuditOperativo)
                                                .Skip(elementiDaSaltare)
                                                .Take(numeroElementi)
                                                .ToList();
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
            int count = _qlikDbContext.ViewQlikDomandaValore.Count();
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

                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikDatiPraticaAudit> result = _qlikDbContext.ViewQlikDatiPraticaAudit
                                                   .OrderByDescending(dati => dati.IdAuditOperativo)
                                                   .Skip(elementiDaSaltare)
                                                   .Take(numeroElementi)
                                                   .ToList();
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
            int count = _qlikDbContext.ViewQlikDatiPraticaAudit.Count();
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

                int totaleElementi = Convert.ToInt32(AuditOperativoAccessoAuditGetTotaleElementiVista());
                int totalePagine = totaleElementi / numeroElementi;
                if (indicePagina > totalePagine)
                {
                    throw new ArgumentException("L'indice della pagina richiesta non può superare il numero di pagine esistenti.");
                }

                int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                IList<ViewQlikAuditOperativoAccesso> result = _qlikDbContext.ViewQlikAuditOperativoAccesso
                                                        .OrderByDescending(dati => dati.IdAuditOperativo)
                                                        .Skip(elementiDaSaltare)
                                                        .Take(numeroElementi)
                                                        .ToList();
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
            int count = _qlikDbContext.ViewQlikAuditOperativoAccesso.Count();
            return count.ToString();
        }
        #endregion
    }
}
