using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_documentacionaduanera
{
    public decimal? TipoDocumento { get; set; }

    public string? NumPedimento { get; set; }

    public string? RFCImpo { get; set; }

    public int? Mercancia_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? IdentDocAduanero { get; set; }
}
