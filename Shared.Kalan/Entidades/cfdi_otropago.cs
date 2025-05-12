using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_otropago
{
    public int? OtroPago_Id { get; set; }

    public decimal? Clave { get; set; }

    public string? Concepto { get; set; }

    public decimal? Importe { get; set; }

    public decimal? TipoOtroPago { get; set; }

    public int? OtrosPagos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
