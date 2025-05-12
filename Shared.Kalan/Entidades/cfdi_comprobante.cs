using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_comprobante
{
    public int Comprobante_Id { get; set; }

    public decimal? Version { get; set; }

    public string? Serie { get; set; }

    public string? Folio { get; set; }

    public string? Sello { get; set; }

    public decimal? FormaPago { get; set; }

    public string? NoCertificado { get; set; }

    public string? Certificado { get; set; }

    public string? CondicionesDePago { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Descuento { get; set; }

    public string? Moneda { get; set; }

    public decimal? TipoCambio { get; set; }

    public decimal? Total { get; set; }

    public string? TipoDeComprobante { get; set; }

    public string? MetodoPago { get; set; }

    public string? LugarExpedicion { get; set; }

    public DateTime? Fecha { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? Exportacion { get; set; }

    public string? Impuestos { get; set; }
}
