using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_impuestosp
{
    public int ImpuestosP_Id { get; set; }

    public int? Pago_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
