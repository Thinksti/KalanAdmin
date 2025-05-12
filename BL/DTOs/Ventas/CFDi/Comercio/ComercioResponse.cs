using Shared.Kalan.Entidades;

namespace KalanBlazor.DTOs.Ventas.CFDi.Comercio
{
    public class ComercioResponse
    {
        public th_venta_factura_comercio_emisor Emisor { get;set; }
        public th_venta_factura_comercio_receptor Receptor { get; set; }
        public th_venta_factura_comercio Encabezado { get; set; }
        public List<th_venta_factura_comercio_mercancias> Mercancias { get; set; }
    }
}
