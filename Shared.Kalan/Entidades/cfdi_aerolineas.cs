using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_aerolineas
{
    public string? Version { get; set; }

    public decimal? TUA { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? Aerolineas_Id { get; set; }
}
