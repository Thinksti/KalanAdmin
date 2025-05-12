using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cfdiregistrofiscal
{
    public string? Version { get; set; }

    public string? Folio { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
