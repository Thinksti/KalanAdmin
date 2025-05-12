using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Ventas
{
    public class DocRelacionado
    {
        public Guid IdDocumento { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string MonedaDR { get; set; }
        public decimal EquivalenciaDR { get; set; }
        public int NumParcialidad { get; set; }
        public decimal ImpSaldoAnt { get; set; }
        public decimal ImpPagado { get; set; }
        public decimal ImpSaldoInsoluto { get; set; }
        public string ObjetoImpDR { get; set; }
        public decimal ImpuestoPagadoMF { get; set; }
        public decimal ImpuestoPagadoM { get; set; }
        public decimal ImportePagadoMF { get; set; }
        public decimal ImportePagadoMO { get; set; }
        public decimal PagoImportePagadoMO { get; set; }
        public decimal PagoImportePagadoMF { get; set; }
        public decimal PagoBasePagadoMO { get; set; }
        public decimal PagoBasePagadoMF { get; set; }
        public decimal PagoIVAPagadoMF { get; set; }
        public decimal PagoIVAPagadoMO { get; set; }
        public float Factor { get; set; }
        public float Factor2 { get; set; }
        public decimal ImpuestoPagadoMFExento { get; set; }
        public decimal ImpuestoPagadoMOExento { get; set; }
        public decimal ImportePagadoMFExento { get; set; }
        public decimal ImportePagadoMOExento { get; set; }
        public decimal ImpuestoPagadoMF16 { get; set; }
        public decimal ImpuestoPagadoMO16 { get; set; }
        public decimal ImportePagadoMF16 { get; set; }
        public decimal ImportePagadoMO16 { get; set; }
        public decimal TC_Rec { get; set; }
        public decimal TC_Fac { get; set; }
        public string SOPNUMBE { get; set; }
    }
}