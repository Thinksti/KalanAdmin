namespace KalanBlazor.DTOs.Ventas.CFDi
{
    public class ConceptoImpuestos
    {
       public decimal Base { get; set; }
        public string Impuesto { get; set; }
        public string TipoFactor { get; set; }
        public string TasaOCuota { get; set; }
        public decimal Importe { get; set; }
        public int Id { get; set; }
    }
}
