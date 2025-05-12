namespace KalanBlazor.BL.Compras.Interfaces
{
    public interface IAplicarCompras : IDisposable
    {
        void AplicarPago(string facturaId, string pagoId, decimal monto, DateTime fecha, string usuario);
        void Dispose();
    }
}
