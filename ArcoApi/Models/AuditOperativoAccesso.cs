using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class AuditOperativoAccesso
    {
        public double? IdAuditOperativo { get; set; }
        public string NomeCampione { get; set; }
        public string DataInizio { get; set; }
        public string DataFine { get; set; }
        public string Ambito { get; set; }
        public string Tipologia { get; set; }
        public double? Versione { get; set; }
        public string CodiceRegione { get; set; }
        public string NomeRegione { get; set; }
        public double? CodiceSede { get; set; }
        public string NomeSede { get; set; }
        public string Rating { get; set; }
        public string Stato { get; set; }
        public double? IdAccesso { get; set; }
        public string NomeAccesso { get; set; }
        public string StatoAccesso { get; set; }
        public string Macroprocesso { get; set; }
        public string Processo { get; set; }
        public double? RatingMacroprocesso { get; set; }
        public double? RatingProcesso { get; set; }
        public double? IsStraordinario { get; set; }
    }
}
