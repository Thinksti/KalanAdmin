using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_identificacionvehicular
{
    public string? ConfigVehicular { get; set; }

    public string? PlacaVM { get; set; }

    public decimal? AnioModeloVM { get; set; }

    public int? Autotransporte_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? PesoBrutoVehicular { get; set; }
}
