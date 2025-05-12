using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_terceros_traslado
{
    public string? impuesto { get; set; }

    public decimal? tasa { get; set; }

    public decimal? importe { get; set; }

    public int? terceros_Traslados_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
