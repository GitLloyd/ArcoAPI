using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class ViewQlikRilievo
    {
        public double? IdIstanzaRilievo { get; set; }
        public double? IdRilievo { get; set; }
        public double? IdDomandaValore { get; set; }
        public string Descrizione { get; set; }
        public string CategoriaRilievo { get; set; }
        public string NotaRilievo { get; set; }
        public string ClassificazioneRilievo { get; set; }
        public double? IdAuditOperativo { get; set; }
        public string CodiceControllo { get; set; }
        public string CodiceNormativa { get; set; }
        public string DescrizioneNormativa { get; set; }
        public double? Certificato { get; set; }
    }
}
