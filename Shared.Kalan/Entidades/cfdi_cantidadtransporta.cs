using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cantidadtransporta
{
    public decimal? Cantidad { get; set; }

    public string? IDOrigen { get; set; }

    public string? IDDestino { get; set; }

    public int? Mercancia_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
