using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_trasladoslocales
{
    public string? ImpLocTrasladado { get; set; }

    public decimal? TasadeTraslado { get; set; }

    public decimal? Importe { get; set; }

    public int? ImpuestosLocales_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
