using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class DatiPraticaAudit

    {
        public double? Progressivo { get; set; }
        public double? IdPratica { get; set; }
        public double? PraticaEliminata { get; set; }
        public double? IdGruppo { get; set; }
        public string NomeGruppo { get; set; }
        public string DescrizioneGruppo { get; set; }
        public string EsitoDettaglio { get; set; }
        public string EsitoGruppo { get; set; }
        public double? IdAuditOperativo { get; set; }
        public double? RatingGruppo { get; set; }
    }
}
