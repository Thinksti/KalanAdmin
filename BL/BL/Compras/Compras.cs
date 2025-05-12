using KalanBlazor.BL.Compras.Interfaces;
using Microsoft.EntityFrameworkCore; 
using Shared.Kalan.Contextos;
using Shared.Kalan.Entidades;
using Shared.Utilerias.Correo;

namespace KalanBlazor.BL.Compras
{
    public class Compras : ICompras
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
        public KalanDB KalanDB { get; }
        public Compras(KalanDB kalanDB)
        {
            KalanDB = kalanDB;
        }
        public async Task Egreso(th_egresos th_egreso)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        entidad.th_egresos.Add(th_egreso);
                        entidad.SaveChanges();
                        var banco = entidad.th_bancos.Find(th_egreso.bancos_id);
                        banco.Saldo -= th_egreso.Original;
                        entidad.Entry(banco).State = EntityState.Modified;
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw;
                    }                    
                }
            }
        }
        public async Task Directa(th_cuentaspagar cuentaspagar)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        entidad.th_cuentaspagar.Add(cuentaspagar);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
        public async Task CancelarDirecta(th_cuentaspagar cuentaspagar)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        entidad.th_cuentaspagar.Update(cuentaspagar);
                        await entidad.SaveChangesAsync();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            
        }
        public async Task CancelarEgreso(th_egresos th_egreso)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        entidad.th_egresos.Update(th_egreso);
                        await entidad.SaveChangesAsync();
                        var chequera = entidad.th_bancos.First(m => m.Id == th_egreso.bancos_id);
                        chequera.Saldo += th_egreso.Original;
                        entidad.th_bancos.Update(chequera);
                        await entidad.SaveChangesAsync();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw;
                    }                    
                }
            }            
        }
    }
}
