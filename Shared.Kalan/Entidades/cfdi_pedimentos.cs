using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_pedimentos
{
    public string? Pedimento { get; set; }

    public int? Mercancia_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
