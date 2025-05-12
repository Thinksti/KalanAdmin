using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_deduccion
{
    public decimal? Clave { get; set; }

    public string? Concepto { get; set; }

    public decimal? Importe { get; set; }

    public decimal? TipoDeduccion { get; set; }

    public int? Deducciones_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
