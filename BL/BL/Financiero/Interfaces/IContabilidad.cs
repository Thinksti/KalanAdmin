namespace KalanBlazor.BL.Financiero.Interfaces
{
    public interface IContabilidad : IDisposable
    {
        Task CancelarComprasDirecto(string Id, string Usuario);
        Task CancelarComprasFactura(string Id, string Usuario);
        Task CancelarEgreso(string Id, string Usuario);
        Task CancelarIngreso(string Id, string Usuario);
        Task CancelarVentasDirecto(string Id, string Usuario);
        Task CancelarVentasFactura(string Id, string Usuario);
        Task ComprasDirecto(string Id, string Usuario);
        Task ComprasFactura(string Id, string Usuario);
        Task Egreso(string Id, string Usuario);
        Task Ingreso(string Id, string Usuario);
        Task VentasDirecto(string Id, string Usuario);
        Task VentasFactura(string Id, string Usuario);
    }
}
