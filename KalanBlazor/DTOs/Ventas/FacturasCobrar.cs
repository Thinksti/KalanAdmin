namespace KalanBlazor.DTOs.Ventas
{
    public class FacturasCobrar
    {
        public string FacturaId { get; set; }
        public string Factura { get; set; }
        public string UUID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoOriginal { get; set; }
        public decimal MontoPendiente { get; set; }
        public decimal MontoPagar { get; set; }
        public bool Aplicar { get; set; }
    }
}
