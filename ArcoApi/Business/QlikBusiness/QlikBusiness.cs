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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikTeam> result = db.ViewQlikTeam
                                           .OrderByDescending(dati => dati.IdAuditOperativo)
                                           .Skip(elementiDaSaltare)
                                           .Take(numeroElementi)
                                           .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikDatiPraticaAudit.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikRilievo> result = db.ViewQlikRilievo
                                              .OrderByDescending(dati => dati.IdAuditOperativo)
                                              .Skip(elementiDaSaltare)
                                              .Take(numeroElementi)
                                              .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikRilievo.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikSede> result = db.ViewQlikSede
                                           .OrderByDescending(dati => dati.CodiceSede)
                                           .Skip(elementiDaSaltare)
                                           .Take(numeroElementi)
                                           .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikSede.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikPraticaGruppo> result = db.ViewQlikPraticaGruppo
                                                    .OrderByDescending(dati => dati.IdAuditOperativo)
                                                    .Skip(elementiDaSaltare)
                                                    .Take(numeroElementi)
                                                    .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikPraticaGruppo.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikDomandaValore> result = db.ViewQlikDomandaValore
                                                    .OrderByDescending(dati => dati.IdAuditOperativo)
                                                    .Skip(elementiDaSaltare)
                                                    .Take(numeroElementi)
                                                    .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikDomandaValore.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikDatiPraticaAudit> result = db.ViewQlikDatiPraticaAudit
                                                       .OrderByDescending(dati => dati.IdAuditOperativo)
                                                       .Skip(elementiDaSaltare)
                                                       .Take(numeroElementi)
                                                       .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikDatiPraticaAudit.Count();
                return count.ToString();
            }
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

                using (var db = new QlikDbContext())
                {
                    int elementiDaSaltare = numeroElementi * (indicePagina - 1);

                    IList<ViewQlikAuditOperativoAccesso> result = db.ViewQlikAuditOperativoAccesso
                                                            .OrderByDescending(dati => dati.IdAuditOperativo)
                                                            .Skip(elementiDaSaltare)
                                                            .Take(numeroElementi)
                                                            .ToList();
                    return result;
                }
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
            using (var db = new QlikDbContext())
            {
                int count = db.ViewQlikAuditOperativoAccesso.Count();
                return count.ToString();
            }
        }
        #endregion
    }
}
