using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class ViewQlikDomandaValore
    {
        public double? IdDomandaValore { get; set; }
        public string Acronimo { get; set; }
        public string Testo { get; set; }
        public int? IdGruppo { get; set; }
        public string Gravita { get; set; }
        public string Risposta { get; set; }
        public string Commento { get; set; }
        public string ProposteDiMiglioramento { get; set; }
        public string NonConformita { get; set; }
        public int? IdAuditOperativo { get; set; }
        public int? IdPratica { get; set; }
        public int? IdDomanda { get; set; }
    }
}
