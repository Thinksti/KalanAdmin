using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_formas_pago
{
    public string Id_Forma_Pago { get; set; } = null!;

    public string? Forma_Pago { get; set; }

    public sbyte Activo { get; set; }
}
