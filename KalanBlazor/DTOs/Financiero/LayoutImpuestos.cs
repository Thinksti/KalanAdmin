namespace KalanBlazor.DTOs.Financiero
{
    public class LayoutImpuestos
    {
        //Nombre	descripción	porcentaje	cuenta contable
        public string Nombre { get; set; }

        public string IdSAT { get; set; }
        
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public string CuentaContable { get; set; }
    }
}
