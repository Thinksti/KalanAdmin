using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_terceros_traslados
{
    public int terceros_Traslados_Id { get; set; }

    public int? terceros_Impuestos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
