using System;
using System.Collections.Generic;

namespace ArcoApi.Models
{
    public partial class ViewQlikTeam
    {
        public string NomeUtente { get; set; }
        public string NomeProfilo { get; set; }
        public string Matricola { get; set; }
        public string CodiceRegione { get; set; }
        public double? CodiceSede { get; set; }
        public string NomeSede { get; set; }
        public string NomeRegione { get; set; }
        public double? IdAuditOperativo { get; set; }
        public double? IsRegioneAccesso { get; set; }
        public string NomeMacroprocesso { get; set; }
        public double? IsDirigenteIspettore { get; set; }
        public double? IsTeamLeader { get; set; }
    }
}
