using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Shared.Kalan.Contexto;



namespace KalanBlazor.BL.Dashboard
{
    public class FacturasSinComplementoCanceladas
    {

        public List<FacturaSCCancelada> ResultadoFacturasSCCancelados()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            var facturasSCCancelados = (from com in KalanDB.cfdi_comprobante
                                        join meta in KalanDB.th_sat_metadata on com.pkUUID.ToString() equals meta.uuid
                                        join conf in KalanDB.th_contabilidad_configuracion on meta.rfcemisor equals conf.RFC into confJoin
                                        from conf in confJoin.DefaultIfEmpty() // Para simular != en SQL usando LINQ
                                        where com.MetodoPago == "PPD" /*&& conf == null*/ // conf == null simula meta.rfcemisor != conf.rfc
                                        && !KalanDB.cfdi_doctorelacionado.Any(doc => doc.IdDocumento == com.pkUUID.ToString())

                                        select new FacturaSCCancelada
                                        {
                                            Serie = com.Serie,
                                            Folio = com.Folio,
                                            pkUUID = com.pkUUID.ToString(),
                                            rfcemisor = meta.rfcemisor,
                                            nombreemisor = meta.nombreemisor,
                                            Fecha = (DateTime)com.Fecha,
                                            Total = (decimal)com.Total,
                                            estatus = meta.estatus,
                                            fechacancelacion = meta.fechacancelacion,
                                            MetodoPago = com.MetodoPago
                                        }).Distinct().ToList();
            Console.WriteLine("Facturas canceladas: " + facturasSCCancelados.Count);
            return facturasSCCancelados;
        }

        //Entidades para facturas sin complemento de pago
        public class FacturaSCCancelada
        {
            public int Numero { get; set; }
            public string Serie { get; set; }
            public string Folio { get; set; }
            public string pkUUID { get; set; }
            public string rfcemisor { get; set; }
            public string nombreemisor { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Total { get; set; }
            public bool estatus { get; set; }
            public DateTime? fechacancelacion { get; set; }
            public string MetodoPago { get; set; }
        }

        public FacturasSinComplementoCanceladas(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }


        //Entidades para facturas totales

        public string CadenaConexion { get; set; }

    }
}
