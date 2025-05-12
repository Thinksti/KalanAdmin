using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retenciones
{
    public int Retenciones_Id { get; set; }

    public int? Impuestos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
