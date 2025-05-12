using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_separacionindemnizacion
{
    public decimal? IngresoAcumulable { get; set; }

    public decimal? IngresoNoAcumulable { get; set; }

    public decimal? NumAñosServicio { get; set; }

    public decimal? TotalPagado { get; set; }

    public decimal? UltimoSueldoMensOrd { get; set; }

    public int? Percepciones_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
