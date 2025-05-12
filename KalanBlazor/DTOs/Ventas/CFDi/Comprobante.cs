namespace KalanBlazor.DTOs.Ventas.CFDi
{
    public class Comprobante
    {
       public string Version { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; }
        public string NoCertificado { get; set; }
        public string Certificado { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal Total { get; set; }
        public string Exportacion { get; set; }
        public string TipoDeComprobante { get; set; }
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; }
    }
}
