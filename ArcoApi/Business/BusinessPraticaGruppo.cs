using ArcoApi.Interfaces;
using ArcoApi.Models;
using ArcoApi.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcoApi.Business
{
    public class BusinessPraticaGruppo : IBusinessPraticaGruppo
    {
        public IList<PraticaGruppo> PraticaGruppoAuditGetElementiPagina(int numeroElementi, int indicePagina)
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

                    IList<PraticaGruppo> result = db.ViewQlikPraticaGruppo
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
    }
}
