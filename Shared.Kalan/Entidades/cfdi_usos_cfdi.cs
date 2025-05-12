using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_usos_cfdi
{
    public string Id_Uso_CFDI { get; set; } = null!;

    public string? Uso_CFDI { get; set; }

    public sbyte PFisicas { get; set; }

    public sbyte PMorales { get; set; }

    public sbyte Activo { get; set; }
}
