using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_subsidioalempleo
{
    public decimal? SubsidioCausado { get; set; }

    public int? OtroPago_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
