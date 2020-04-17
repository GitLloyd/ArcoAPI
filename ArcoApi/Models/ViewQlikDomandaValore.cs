using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class ViewQlikDomandaValore
    {
        public double? IdDomandaValore { get; set; }
        public string Acronimo { get; set; }
        public string Testo { get; set; }
        public double? IdGruppo { get; set; }
        public string Gravita { get; set; }
        public string Risposta { get; set; }
        public string Commento { get; set; }
        public string ProposteDiMiglioramento { get; set; }
        public string NonConformita { get; set; }
        public double? IdAuditOperativo { get; set; }
        public double? IdPratica { get; set; }
        public double? IdDomanda { get; set; }
    }
}
