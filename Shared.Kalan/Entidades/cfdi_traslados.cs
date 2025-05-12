using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_traslados
{
    public int Traslados_Id { get; set; }

    public int? Impuestos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
