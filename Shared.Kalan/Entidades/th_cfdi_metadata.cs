using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_cfdi_metadata
{
    public string Uuid { get; set; } = null!;

    public string? RfcEmisor { get; set; }

    public string? NombreEmisor { get; set; }

    public string? RfcReceptor { get; set; }

    public string? NombreReceptor { get; set; }

    public string? RfcPac { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaCertificacionSat { get; set; }

    public decimal? Monto { get; set; }

    public string? EfectoComprobante { get; set; }

    public int? Estatus { get; set; }

    public DateTime? FechaCancelacion { get; set; }

    public bool? XML { get; set; }

    public DateTime? FechaDescarga { get; set; }
}
