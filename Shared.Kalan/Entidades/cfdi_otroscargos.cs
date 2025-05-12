using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_otroscargos
{
    public int OtrosCargos_Id { get; set; }

    public decimal? TotalCargos { get; set; }

    public int? Aerolineas_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
