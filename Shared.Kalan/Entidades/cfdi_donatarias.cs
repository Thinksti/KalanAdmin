using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_donatarias
{
    public string? version { get; set; }

    public string? noAutorizacion { get; set; }

    public string? fechaAutorizacion { get; set; }

    public string? leyenda { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
