using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_informacionglobal
{
    public Guid? pkUUID { get; set; }

    public string? Periodicidad { get; set; }

    public string? Meses { get; set; }

    public string? Año { get; set; }

    public int? Comprobante_Id { get; set; }
}
