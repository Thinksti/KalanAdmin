using DocumentFormat.OpenXml.InkML;
using KalanBlazor.BL.Financiero.Interfaces;
using KalanBlazor.DTOs.Financiero;
using Microsoft.EntityFrameworkCore;
using Shared.Kalan.Contexto;
using Shared.Kalan.Entidades;

namespace KalanBlazor.BL.Financiero
{
    public class Contabilidad : IContabilidad
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

        private th_contabilidad_cuenta_configuracion Configuracion { get; set; }
        public Contabilidad(KalanDB kalanDB)
        {
            KalanDB = kalanDB;
            Configuracion = KalanDB.th_contabilidad_cuenta_configuracion.FirstOrDefault();
        }
        public async Task ComprasFactura(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_compra_factura
                                        .Where(x => x.Id == Id)
                                        .Include(x => x.th_compra_factura_detalle)
                                        .Include(x => x.th_compra_factura_detalle).ThenInclude(x => x.articulo)
                                        .Include(x => x.th_compra_factura_detalle).ThenInclude(x => x.planimpuestos).ThenInclude(x => x.th_plan_impuestos_detalle).ThenInclude(x => x.impuestos)
                                        .Include(x => x.IdNavigation.proveedor)
                                        .FirstOrDefault();
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable proveedor = new PartidaContable
                        {
                            CuentaContable = documento.IdNavigation.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = documento.Total,
                            Debitos = 0
                        };
                        partidas.Add(proveedor);
                        if (documento.MontoImpuestos != 0)
                        {
                            foreach (var item in documento.th_compra_factura_detalle)
                            {
                                if (item.planimpuestos != null)
                                {
                                    foreach (var impuestodetalle in item.planimpuestos.th_plan_impuestos_detalle)
                                    {
                                        if (impuestodetalle.impuestos.Porcentaje > 0)
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = 0,
                                                Debitos = item.Impuesto
                                            };
                                            partidas.Add(impuesto);
                                        }
                                        else
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = item.Impuesto,
                                                Debitos = 0
                                            };
                                            partidas.Add(impuesto);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in documento.th_compra_factura_detalle)
                        {
                            var detalle = new PartidaContable
                            {
                                CuentaContable = item.articulo.cuentacontable_id,
                                Descripcion = "Compra",
                                Creditos = 0,
                                Debitos = item.SubTotal
                            };
                            partidas.Add(detalle);
                        }
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Compra"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task VentasFactura(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_venta_factura
              .Where(x => x.Id == Id)
                              .Include(x => x.th_venta_factura_detalle)
              .Include(x => x.th_venta_factura_detalle).ThenInclude(x => x.articulo)
              .Include(x => x.th_venta_factura_detalle).ThenInclude(x => x.planimpuestos).ThenInclude(x => x.th_plan_impuestos_detalle).ThenInclude(x => x.impuestos)
              .Include(x => x.IdNavigation.cliente)
              .FirstOrDefault();
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable proveedor = new PartidaContable
                        {
                            CuentaContable = documento.IdNavigation.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = documento.Total,
                            Debitos = 0
                        };
                        partidas.Add(proveedor);
                        if (documento.MontoImpuestos != 0)
                        {
                            foreach (var item in documento.th_venta_factura_detalle)
                            {
                                if (item.planimpuestos != null)
                                {
                                    foreach (var impuestodetalle in item.planimpuestos.th_plan_impuestos_detalle)
                                    {
                                        if (impuestodetalle.impuestos.Porcentaje > 0)
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = 0,
                                                Debitos = item.Impuesto
                                            };
                                            partidas.Add(impuesto);
                                        }
                                        else
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = item.Impuesto,
                                                Debitos = 0
                                            };
                                            partidas.Add(impuesto);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in documento.th_venta_factura_detalle)
                        {
                            var detalle = new PartidaContable
                            {
                                CuentaContable = item.articulo.cuentacontable_id,
                                Descripcion = "Venta",
                                Creditos = 0,
                                Debitos = item.SubTotal
                            };
                            partidas.Add(detalle);
                        }
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var numAsiento = 1;
                        if (entidad.th_contabilidad_trabajo.Any())
                        {
                            numAsiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = numAsiento,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Factura,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Venta"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;

                        var facturaEntity = entidad.Set<th_venta_factura>().Find(documento.Id);
                        entidad.Entry(facturaEntity).CurrentValues.SetValues(documento);

                        //entidad.Update(documento);
                        entidad.SaveChanges();
                        var cuentaxcobrar = entidad.th_cuentascobrar.FirstOrDefault(x => x.Id == documento.Id);
                        if (cuentaxcobrar != null)
                        {
                            cuentaxcobrar.asiento_Id = encabezado.Id;
                            var existingEntity = entidad.Set<th_cuentascobrar>().Find(cuentaxcobrar.Id);
                            if (existingEntity != null)
                            {
                                entidad.Entry(existingEntity).CurrentValues.SetValues(cuentaxcobrar);
                            }
                            else
                            {
                                entidad.Attach(cuentaxcobrar);
                            } 
                            entidad.SaveChanges();
                        } 
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                    }
                }
                return;
            }
        }
 
        public async Task VentasDirecto(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_cuentascobrar.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = 0,
                            Debitos = documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = documento.Original,
                            CuentaContable = Configuracion.cuentaventa_Id,
                            Debitos = 0,
                            Descripcion = "Venta"
                        };
                        partidas.Add(banco); 
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Venta Directa"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges(); 
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                     
                    }
                }
            }
        }
        public async Task ComprasDirecto(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_cuentaspagar.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = 0,
                            Debitos = documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = documento.Original,
                            CuentaContable = Configuracion.cuentacompra_Id,
                            Debitos = 0,
                            Descripcion = "Compra"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Compra Directa"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                     
                    }
                }
            }
        }
        public async Task Ingreso(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_ingresos.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = 0,
                            Debitos = documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = documento.Original,
                            CuentaContable = documento.bancos.cuentacontable_id,
                            Debitos = 0,
                            Descripcion = "Banco"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Ingreso"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task Egreso(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_egresos.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asiento_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {
                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = 0,
                            Debitos = documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = documento.Original,
                            CuentaContable = documento.bancos.cuentacontable_id,
                            Debitos = 0,
                            Descripcion = "Banco"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 1,
                            Origen = "Egreso"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asiento_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task CancelarComprasFactura(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_compra_factura
            .Where(x => x.Id == Id)
                            .Include(x => x.th_compra_factura_detalle)
            .Include(x => x.th_compra_factura_detalle).ThenInclude(x => x.articulo)
            .Include(x => x.th_compra_factura_detalle).ThenInclude(x => x.planimpuestos).ThenInclude(x => x.th_plan_impuestos_detalle).ThenInclude(x => x.impuestos)
            .Include(x => x.IdNavigation.proveedor)
            .FirstOrDefault();
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable proveedor = new PartidaContable
                        {
                            CuentaContable = documento.IdNavigation.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = -documento.Total,
                            Debitos = 0
                        };
                        partidas.Add(proveedor);
                        if (documento.MontoImpuestos != 0)
                        {
                            foreach (var item in documento.th_compra_factura_detalle)
                            {
                                if (item.planimpuestos != null)
                                {
                                    foreach (var impuestodetalle in item.planimpuestos.th_plan_impuestos_detalle)
                                    {
                                        if (impuestodetalle.impuestos.Porcentaje > 0)
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = 0,
                                                Debitos = -item.Impuesto
                                            };
                                            partidas.Add(impuesto);
                                        }
                                        else
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = -item.Impuesto,
                                                Debitos = 0
                                            };
                                            partidas.Add(impuesto);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in documento.th_compra_factura_detalle)
                        {
                            var detalle = new PartidaContable
                            {
                                CuentaContable = item.articulo.cuentacontable_id,
                                Descripcion = "Compra",
                                Creditos = 0,
                                Debitos = -item.SubTotal
                            };
                            partidas.Add(detalle);
                        }
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Compra Cancelada"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task CancelarVentasFactura(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_venta_factura
              .Where(x => x.Id == Id)
                              .Include(x => x.th_venta_factura_detalle)
              .Include(x => x.th_venta_factura_detalle).ThenInclude(x => x.articulo)
              .Include(x => x.th_venta_factura_detalle).ThenInclude(x => x.planimpuestos).ThenInclude(x => x.th_plan_impuestos_detalle).ThenInclude(x => x.impuestos)
              .Include(x => x.IdNavigation.cliente)
              .FirstOrDefault();
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable proveedor = new PartidaContable
                        {
                            CuentaContable = documento.IdNavigation.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = -documento.Total,
                            Debitos = 0
                        };
                        partidas.Add(proveedor);
                        if (documento.MontoImpuestos != 0)
                        {
                            foreach (var item in documento.th_venta_factura_detalle)
                            {
                                if (item.planimpuestos != null)
                                {
                                    foreach (var impuestodetalle in item.planimpuestos.th_plan_impuestos_detalle)
                                    {
                                        if (impuestodetalle.impuestos.Porcentaje > 0)
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = 0,
                                                Debitos = -item.Impuesto
                                            };
                                            partidas.Add(impuesto);
                                        }
                                        else
                                        {
                                            var impuesto = new PartidaContable
                                            {
                                                CuentaContable = impuestodetalle.impuestos.cuentacontable_id,
                                                Descripcion = impuestodetalle.impuestos.Descripcion,
                                                Creditos = -item.Impuesto,
                                                Debitos = 0
                                            };
                                            partidas.Add(impuesto);
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var item in documento.th_venta_factura_detalle)
                        {
                            var detalle = new PartidaContable
                            {
                                CuentaContable = item.articulo.cuentacontable_id,
                                Descripcion = "Venta",
                                Creditos = 0,
                                Debitos = -item.SubTotal
                            };
                            partidas.Add(detalle);
                        }
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Venta Cancelada"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;

                        var existingEntityF = entidad.Set<th_venta_factura>().Find(documento.Id);
                        if (existingEntityF != null)
                        {
                            entidad.Entry(existingEntityF).CurrentValues.SetValues(documento);
                        }
                        else
                        {
                            entidad.Attach(documento);
                        }
                        entidad.SaveChanges();
 
                        var cuentaxcobrar = entidad.th_cuentascobrar.FirstOrDefault(x => x.Id == documento.Id);
                        if (cuentaxcobrar != null)
                        {
                            cuentaxcobrar.asiento_Id = encabezado.Id;
                            var existingEntity = entidad.Set<th_cuentascobrar>().Find(cuentaxcobrar.Id);
                            if (existingEntity != null)
                            {
                                entidad.Entry(existingEntity).CurrentValues.SetValues(cuentaxcobrar);
                            }
                            else
                            {
                                entidad.Attach(cuentaxcobrar);
                            }
                            entidad.SaveChanges();
                        }
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                    
                    }
                }

            }
        }
        public async Task CancelarIngreso(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_ingresos.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = 0,
                            Debitos = -documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = -documento.Original,
                            CuentaContable = documento.bancos.cuentacontable_id,
                            Debitos = 0,
                            Descripcion = "Banco"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Ingreso Cancelado"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                 
                    }
                }
            }
        }
        public async Task CancelarEgreso(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_egresos.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = 0,
                            Debitos = -documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = -documento.Original,
                            CuentaContable = documento.bancos.cuentacontable_id,
                            Debitos = 0,
                            Descripcion = "Banco"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Egreso Cancelado"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task CancelarComprasDirecto(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_cuentaspagar.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.proveedor.cuentacontable_id,
                            Descripcion = "Cuenta por Pagar",
                            Creditos = 0,
                            Debitos = -documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = -documento.Original,
                            CuentaContable = Configuracion.cuentacompra_Id,
                            Debitos = 0,
                            Descripcion = "Compra"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Compra Directa Cancelada"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                   
                    }
                }
            }
        }
        public async Task CancelarVentasDirecto(string Id, string Usuario)
        {
            using (var entidad = new KalanDB(KalanDB.connectionString))
            {
                var documento = entidad.th_cuentascobrar.FirstOrDefault(x => x.Id == Id);
                if (documento == null)
                {
                    return;
                }
                if (string.IsNullOrEmpty(documento.asientocancelado_Id) == false)
                {
                    return;
                }
                using (var transaccion = entidad.Database.BeginTransaction())
                {
                    try
                    {

                        var tc = entidad.th_tiposcambio.FirstOrDefault(x => x.Id == documento.tipocambio_Id);
                        var partidas = new List<PartidaContable>();
                        PartidaContable cuenta = new PartidaContable
                        {
                            CuentaContable = documento.cliente.cuentacontable_id,
                            Descripcion = "Cuenta por Cobrar",
                            Creditos = 0,
                            Debitos = -documento.Original
                        };
                        partidas.Add(cuenta);
                        PartidaContable banco = new PartidaContable
                        {
                            Creditos = -documento.Original,
                            CuentaContable = Configuracion.cuentaventa_Id,
                            Debitos = 0,
                            Descripcion = "Venta"
                        };
                        partidas.Add(banco);
                        if (partidas.Where(x => string.IsNullOrEmpty(x.CuentaContable)).Count() > 0)
                        {
                            return;
                        }
                        var encabezado = new th_contabilidad_trabajo
                        {
                            Activo = true,
                            FechaCreacion = DateTime.Now,
                            Asiento = entidad.th_contabilidad_trabajo.Max(x => x.Asiento) + 1,
                            UsuarioCreacion = Usuario,
                            Fecha = documento.Fecha,
                            Año = documento.Fecha.Year,
                            DocumentoOriginal = documento.Id,
                            Id = Guid.NewGuid().ToString(),
                            Mes = documento.Fecha.Month,
                            moneda_Id = documento.moneda_Id,
                            tipocambio_Id = documento.tipocambio_Id,
                            Tipo = 2,
                            Origen = "Venta Directa Cancelada"
                        };
                        entidad.th_contabilidad_trabajo.Add(encabezado);
                        entidad.SaveChanges();
                        foreach (var item in partidas)
                        {
                            var detalle = new th_contabilidad_trabajo_detalle
                            {
                                Id = Guid.NewGuid().ToString(),
                                Credito = item.Creditos,
                                CreditoMF = item.Creditos * tc.TipoCambio,
                                cuenta_Id = item.CuentaContable,
                                Debito = item.Debitos,
                                DebitoMF = item.Debitos * tc.TipoCambio,
                                encabezado_Id = encabezado.Id,
                                FechaCreacion = DateTime.Now,
                                TipoConcepto = item.Descripcion,
                                UsuarioCreacion = Usuario
                            };
                            entidad.th_contabilidad_trabajo_detalle.Add(detalle);
                            entidad.SaveChanges();
                        }
                        documento.asientocancelado_Id = encabezado.Id;
                        entidad.Update(documento);
                        entidad.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        
                    }
                }
            }
        }
    }
}
