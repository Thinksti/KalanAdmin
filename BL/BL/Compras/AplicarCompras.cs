using KalanBlazor.BL.Compras.Interfaces;
using Shared.Kalan.Contexto;
using Shared.Kalan.Entidades;

namespace KalanBlazor.BL.Compras
{
    public class AplicarCompras: IAplicarCompras
    {
        private bool disposedValue;

        public AplicarCompras(KalanDB kalanDB)
        {
            KalanDB = kalanDB;
        }
        public void AplicarPago(string facturaId, string pagoId, decimal monto, DateTime fecha, string usuario)
        {
            using var transaction = KalanDB.Database.BeginTransaction();
            try
            {
                var factura = KalanDB.th_cuentaspagar.Find(facturaId);
                var pago = KalanDB.th_egresos.Find(pagoId);
                var aplicacion = new th_cuentaspagaraplicaciones
                {
                    cuentaspagar_Id = facturaId,
                    egreso_Id = pagoId,
                    FechaAplicacion = fecha,
                    FechaCreacion = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    MontoAplicado = monto,
                    proveedor_Id = factura.proveedor_Id,
                    UsuarioCreacion = usuario
                };
                KalanDB.th_cuentaspagaraplicaciones.Add(aplicacion);
                KalanDB.SaveChanges();
                factura.Disponible -= monto;
                factura.UsuarioModifica = usuario;
                factura.FechaModifica = DateTime.Now;
                KalanDB.th_cuentaspagar.Update(factura);
                KalanDB.SaveChanges();
                pago.Disponible -= monto;
                pago.UsuarioModifica = usuario;
                pago.FechaModifica = DateTime.Now;
                KalanDB.th_egresos.Update(pago);
                KalanDB.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public KalanDB KalanDB { get; }

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
    }
}
