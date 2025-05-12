namespace KalanBlazor.DTOs.Ventas.CFDi
{
    public class Concepto
    {
       public string ClaveProdServ { get; set; }
       public string ClaveUnidad { get; set; }
        public string NoIdentificacion { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Importe { get; set; }
        public string ObjetoImp { get; set; }
        public decimal Descuento { get; set; }
        public int Id { get; set; }
    }
}
