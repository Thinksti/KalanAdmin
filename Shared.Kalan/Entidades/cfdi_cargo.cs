using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cargo
{
    public string? CodigoCargo { get; set; }

    public decimal? Importe { get; set; }

    public int? OtrosCargos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
