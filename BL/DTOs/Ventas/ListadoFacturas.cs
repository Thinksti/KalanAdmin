namespace KalanBlazor.DTOs.Ventas
{
    public class ListadoFacturas
    {
        public string UUID { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public string MetodoPago { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_Original { get; set; }
        public decimal Monto_Disponible { get; set; }
        public bool Activo { get; set; }
        public string Usuario { get; set; }
    }
}
