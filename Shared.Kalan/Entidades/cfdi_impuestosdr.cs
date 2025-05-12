using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_impuestosdr
{
    public int ImpuestosDR_Id { get; set; }

    public int? DoctoRelacionado_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
