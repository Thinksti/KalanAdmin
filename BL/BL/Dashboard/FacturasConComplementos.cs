using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Dashboard
{
    public class FacturasConComplementos
    {

        //Logica de consulta de facturas con complemento de pago quitando el join que excluye las facturas que tienen complemento de pago
        public List<FacturaCC> ResultadoFacturasCC()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            // Consulta para obtener las facturas con complemento de pago
            var facturasCC = (from doc in KalanDB.cfdi_doctorelacionado
                              join meta in KalanDB.th_sat_metadata
                              on doc.pkUUID.ToString() equals meta.uuid
                              where meta.estatus.ToString() == "1" && meta.rfcemisor != "KCM210429N64"
                              select new FacturaCC
                              {
                                  pkUUID = doc.pkUUID.ToString(),
                                  rfcemisor = meta.rfcemisor,

                              })
                     .Distinct().ToList();
            return facturasCC;
        }





        public decimal SumaTotalValorComplementos()
        {
            using (var KalanDB = new KalanDB(CadenaConexion))
            {
                // Paso 1: Obtener los pkUUID únicos
                var complementosUnicos = (from doc in KalanDB.cfdi_doctorelacionado
                                          join meta in KalanDB.th_sat_metadata
                                          on doc.pkUUID.ToString() equals meta.uuid
                                          where meta.estatus.ToString() == "1" && meta.rfcemisor != "KCM210429N64"
                                          select doc.pkUUID).Distinct().ToList(); // Ejecutar la primera consulta


                var complementosFacturas = (from sub in KalanDB.cfdi_doctorelacionado  // Obtenemos los complementos de la tabla doctorelacioando
                                            group sub by new { sub.IdDocumento, sub.pkUUID } into g // Agrupar los registros por IdDocumento y pkUUID
                                            select g.OrderBy(x => x.IdDocumento).First()).ToList(); // Ordenar los grupos mediante el IdDocumento, ejecutar la segunda consulta y almacenarlo en una lista

                // Paso 3: Realizar el Join y calcular la suma
                var resultado = (from cu in complementosUnicos
                                 join cf in complementosFacturas
                                 on cu equals cf.pkUUID
                                 select cf.ImpPagado).Sum();

                return (decimal)resultado;
            }
        }


        // Método para sumar los montos de las facturas con complemento de pago
        public decimal SumarMontosFacturasCC(List<FacturaCC> facturascc)
        {
            if (facturascc == null || facturascc.Count == 0)
            {
                return 0;
            }

            return facturascc.Sum(facturascc => facturascc.Total);
        }


        public FacturasConComplementos(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }

        /// <summary>
        /// Entidades de las facturas con complemento de pago
        /// </summary>
        public class FacturaCC
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
