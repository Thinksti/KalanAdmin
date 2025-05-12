using KalanBlazor.BL.Ventas.Interfaces;
using Shared.Kalan.Contextos;
using Shared.Kalan.Entidades;

namespace KalanBlazor.BL.Ventas
{
    public class Aplicar : IAplicar
    {
        private bool disposedValue; 
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public Aplicar(KalanDB kalanDB)
        {
            KalanDB = kalanDB;
        }
        public KalanDB KalanDB { get; }
        public void AplicarPago(string facturaId, string pagoId, decimal monto, DateTime fecha, string usuario)
        {
            using var transaction = KalanDB.Database.BeginTransaction();
            try
            {
                var factura = KalanDB.th_cuentascobrar.Find(facturaId);
                var pago = KalanDB.th_ingresos.Find(pagoId);
                var aplicacion = new th_cuentascobraraplicaciones
                {
                    cuentascobrar_Id = facturaId,
                    ingreso_Id = pagoId,
                    FechaAplicacion = fecha,
                    FechaCreacion = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    MontoAplicado = monto,
                    cliente_Id = factura.cliente_Id,
                    UsuarioCreacion = usuario
                };
                KalanDB.th_cuentascobraraplicaciones.Add(aplicacion);
                KalanDB.SaveChanges();
                factura.Disponible -= monto;
                factura.UsuarioModifica = usuario;
                factura.FechaModifica = DateTime.Now;
                KalanDB.th_cuentascobrar.Update(factura);
                KalanDB.SaveChanges();
                pago.Disponible -= monto;
                pago.UsuarioModifica = usuario;
                pago.FechaModifica = DateTime.Now;
                KalanDB.th_ingresos.Update(pago);
                KalanDB.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
 
    }
}
