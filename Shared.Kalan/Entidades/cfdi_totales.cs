using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_totales
{
    public decimal? MontoTotalPagos { get; set; }

    public decimal? TotalTrasladosBaseIVA16 { get; set; }

    public decimal? TotalTrasladosImpuestoIVA16 { get; set; }

    public int? Pagos_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? TotalRetencionesIVA { get; set; }

    public decimal? TotalRetencionesISR { get; set; }

    public decimal? TotalTrasladosBaseIVA8 { get; set; }

    public decimal? TotalTrasladosImpuestoIVA8 { get; set; }

    public decimal? TotalTrasladosBaseIVA0 { get; set; }

    public decimal? TotalTrasladosImpuestoIVA0 { get; set; }

    public decimal? TotalTrasladosBaseIVAExento { get; set; }

    public decimal? TotalRetencionesIEPS { get; set; }
}
