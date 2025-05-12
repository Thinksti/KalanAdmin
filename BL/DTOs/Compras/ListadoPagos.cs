namespace KalanBlazor.DTOs.Compras
{
    public class ListadoPagos
    {
        public string Documento { get; set; }
        public string Observaciones { get; set; }
        public string Id { get; set; }
        public string Chequera { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_Original { get; set; }
        public decimal Monto_Disponible { get; set; }
        public bool Activo { get; set; }
        public string Usuario { get; set; }
    }
}