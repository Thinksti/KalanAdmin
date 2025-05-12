using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retencion_1
{
    public decimal? importe { get; set; }

    public string? impuesto { get; set; }

    public int? terceros_Retenciones_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
