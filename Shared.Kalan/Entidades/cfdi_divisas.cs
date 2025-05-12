using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_divisas
{
    public string? version { get; set; }

    public string? tipoOperacion { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
