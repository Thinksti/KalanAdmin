using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_error
{
    public Guid? pkUUID { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Error { get; set; }

    public string? Archivo { get; set; }
}
