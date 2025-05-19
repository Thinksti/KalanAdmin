using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Dashboard
{
    public class FacturasSinComplementos
    {
        /// <summary>
        /// Obtiene las facturas sin complemento de pago
        /// </summary>
        public List<FacturaSC> ResultadoFacturasSC()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            var facturasSC = (from com in KalanDB.cfdi_comprobante
                              join meta in KalanDB.th_sat_metadata on com.pkUUID.ToString() equals meta.uuid
                              join conf in KalanDB.th_contabilidad_configuracion on meta.rfcemisor equals conf.RFC into confJoin
                              from conf in confJoin.DefaultIfEmpty() // Para simular != en SQL usando LINQ
                              where com.MetodoPago == "PPD" && conf == null // conf == null simula meta.rfcemisor != conf.rfc
                              && !KalanDB.cfdi_doctorelacionado.Any(doc => doc.IdDocumento == com.pkUUID.ToString())

                              select new FacturaSC
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

            for (int i = 0; i < facturasSC.Count; i++)
            {
                facturasSC[i].Numero = i + 1; // Empezar desde 1
            }

            decimal sumaMontos = SumarMontosFacturasSC(facturasSC);

            Console.WriteLine("Facturas sin complemento de pago: " + facturasSC.Count);
            return facturasSC;
        }

        /// <summary>
        /// Suma los montos de las facturas sin complemento de pago
        public decimal SumarMontosFacturasSC(List<FacturaSC> facturas)
        {
            if (facturas == null || facturas.Count == 0)
            {
                return 0;
            }

            Console.WriteLine("Suma de montos de facturas sin complemento de pago: " + facturas.Sum(facturas => facturas.Total));
            return facturas.Sum(facturas => facturas.Total);
        }

        public FacturasSinComplementos(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }

        //Entidades para facturas sin complemento de pago
        public class FacturaSC
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

        public string CadenaConexion { get; set; }
    }
}
