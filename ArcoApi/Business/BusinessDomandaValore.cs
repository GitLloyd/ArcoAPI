using ArcoApi.Interfaces;
using ArcoApi.Models;
using ArcoApi.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcoApi.Business
{
    public class BusinessDomandaValore : IBusinessDomandaValore
    {
        public IList<DomandaValore> DomandaValoreGetElementiPagina(int numeroElementi, int indicePagina)
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

                    IList<DomandaValore> result = db.ViewQlikDomandaValore
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
    }
}
