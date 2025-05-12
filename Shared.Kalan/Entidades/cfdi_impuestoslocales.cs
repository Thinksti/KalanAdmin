using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_impuestoslocales
{
    public int ImpuestosLocales_Id { get; set; }

    public string? version { get; set; }

    public decimal? TotaldeRetenciones { get; set; }

    public decimal? TotaldeTraslados { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
