using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_trasladop
{
    public decimal? BaseP { get; set; }

    public decimal? ImpuestoP { get; set; }

    public string? TipoFactorP { get; set; }

    public decimal? TasaOCuotaP { get; set; }

    public decimal? ImporteP { get; set; }

    public int? TrasladosP_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
