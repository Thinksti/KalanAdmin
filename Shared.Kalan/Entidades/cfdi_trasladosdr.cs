using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_trasladosdr
{
    public int TrasladosDR_Id { get; set; }

    public int? ImpuestosDR_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
