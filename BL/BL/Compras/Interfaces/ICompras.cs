using Shared.Kalan.Entidades;

namespace KalanBlazor.BL.Compras.Interfaces
{
    public interface ICompras : IDisposable
    {
        Task Egreso(th_egresos th_egreso);
        void Dispose();
        Task CancelarEgreso(th_egresos th_egreso);
        Task Directa(th_cuentaspagar cuentaspagar);
        Task CancelarDirecta(th_cuentaspagar cuentaspagar);
    }
}
