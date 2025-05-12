using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_remolques
{
    public int Remolques_Id { get; set; }

    public int? Autotransporte_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
