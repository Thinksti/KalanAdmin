using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_remolque
{
    public string? SubTipoRem { get; set; }

    public string? Placa { get; set; }

    public int? Remolques_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
