namespace KalanBlazor.DTOs.Financiero
{
    public class ConciliaDocumentos
    {
        public string uuid { get; set; } = null!;

        public string rfcemisor { get; set; } = null!;

        public string nombreemisor { get; set; } = null!;

        public string rfcreceptor { get; set; } = null!;

        public string nombrereceptor { get; set; } = null!;

        public string rfcpac { get; set; } = null!;

        public DateTime fechaemision { get; set; }

        public DateTime fechacertificacionsat { get; set; }

        public decimal monto { get; set; }

        public string efectocomprobante { get; set; } = null!;

        public bool estatus { get; set; }

        public DateTime? fechacancelacion { get; set; }
        public bool Existe { get; set; }
    }
}
