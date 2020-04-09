using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcoApi.Interfaces;
using ArcoApi.Models;
using ArcoApi.Repository;
using Microsoft.Data.SqlClient;

namespace ArcoApi.Business
{
    public class BusinessDatiPraticaAudit : IBusinessDatiPraticaAudit
    {
        public IList<DatiPraticaAudit> DatiPraticaAuditGetElementiPagina(int numeroElementi, int indicePagina)
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

                    IList<DatiPraticaAudit> result = db.ViewQlikDatiPraticaAudit
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
    }
}
