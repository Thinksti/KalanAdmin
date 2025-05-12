using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_autotransporte
{
    public int Autotransporte_Id { get; set; }

    public string? PermSCT { get; set; }

    public string? NumPermisoSCT { get; set; }

    public int? Mercancias_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
