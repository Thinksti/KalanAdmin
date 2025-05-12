using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retencion
{
    public decimal? Base { get; set; }

    public decimal? Importe { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? TasaOCuota { get; set; }

    public string? TipoFactor { get; set; }

    public int? Retenciones_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
