using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_tiposfigura
{
    public int? TiposFigura_Id { get; set; }

    public decimal? TipoFigura { get; set; }

    public string? RFCFigura { get; set; }

    public string? NombreFigura { get; set; }

    public string? NumLicencia { get; set; }

    public int? FiguraTransporte_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
