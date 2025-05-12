namespace KalanBlazor.BL.Ventas.Interfaces
{
    public interface IAplicar : IDisposable
    {
        void AplicarPago(string facturaId, string pagoId, decimal monto, DateTime fecha, string usuario);
        void Dispose();
    }
}
