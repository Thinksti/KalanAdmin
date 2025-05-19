using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Dashboard
{
    public class FacturasTodas
    {
        // Logica de consulta de facturas totales
        public List<FacturaTSC> ResultadoFacturasTodas()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            var facturasTSC = (from com in KalanDB.cfdi_comprobante
                               join meta in KalanDB.th_sat_metadata on com.pkUUID.ToString() equals meta.uuid
                               join conf in KalanDB.th_contabilidad_configuracion on meta.rfcemisor equals conf.RFC into confGroup
                               from conf in confGroup.DefaultIfEmpty()
                               where com.MetodoPago == "PPD" && meta.rfcemisor != conf.RFC
                               select new FacturaTSC
                               {
                                   Serie = com.Serie,
                                   Folio = com.Folio,
                                   pkUUID = com.pkUUID.ToString(),
                                   rfcemisor = meta.rfcemisor,
                                   nombreemisor = meta.nombreemisor,
                                   Fecha = com.Fecha.Value,
                                   Total = com.Total.Value,
                                   estatus = meta.estatus,
                                   fechacancelacion = meta.fechacancelacion,
                                   MetodoPago = com.MetodoPago
                               }).Distinct().ToList();

            decimal sumaMontosTds = SumarMontosFacturasTodas(facturasTSC);
            //Console.WriteLine(sumaMontosTds);
            return facturasTSC;
        }


        // Método para sumar los montos de las facturas totales
        public decimal SumarMontosFacturasTodas(List<FacturaTSC> facturasTds)
        {
            if (facturasTds == null || facturasTds.Count == 0)
            {
                return 0;
            }

            return facturasTds.Sum(facturasTds => facturasTds.Total);
        }

        public FacturasTodas(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }

        //Entidades para facturas sin complemento de pago
        public class FacturaTSC
        {
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

        //Entidades para facturas totales
        public string CadenaConexion { get; set; }

    }
}
