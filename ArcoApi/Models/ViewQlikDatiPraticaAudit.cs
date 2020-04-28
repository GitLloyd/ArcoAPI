using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcoApi.Models
{
    public partial class ViewQlikDatiPraticaAudit
    {
        public string Audit               { get; set; }
        public string AmbitoAudit         { get; set; }
        public string TipologiaAudit      { get; set; }
        public string Stato               { get; set; }
        public double? ProgressivoPratica    { get; set; }
        [Column("Numero Caso")]
        public string NumeroCaso          { get; set; }
        [Column("Codice Sede")]
        public string CodiceSede          { get; set; }
        public string Infortunio          { get; set; }
        public string Sede                { get; set; }
        public string Pratica             { get; set; }
        public string Tipologia           { get; set; }
        [Column("Numero pratica")]
        public string NumeroPratica       { get; set; }
        [Column("N° Progr. progetto")]
        public string NumeroProgrProgetto { get; set; }
        [Column("Ragione sociale")]
        public string RagioneSociale      { get; set; }
        [Column("Codice ditta")]
        public string CodiceDitta         { get; set; }
        public string Ditta               { get; set; }
        public string Matricola           { get; set; }
        [Column("N. Caso fornitura")]
        public string NumeroCasoFornitura { get; set; }
        [Column("Numero Domanda")]
        public string NumeroDomanda       { get; set; }
    }
}
