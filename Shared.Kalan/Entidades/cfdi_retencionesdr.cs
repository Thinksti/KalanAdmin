using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retencionesdr
{
    public int RetencionesDR_Id { get; set; }

    public int? ImpuestosDR_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
