using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_trasladodr
{
    public decimal? BaseDR { get; set; }

    public decimal? ImporteDR { get; set; }

    public decimal? ImpuestoDR { get; set; }

    public decimal? TasaOCuotaDR { get; set; }

    public string? TipoFactorDR { get; set; }

    public int? TrasladosDR_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
