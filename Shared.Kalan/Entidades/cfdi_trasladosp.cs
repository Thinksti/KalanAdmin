using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_trasladosp
{
    public int TrasladosP_Id { get; set; }

    public int? ImpuestosP_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
