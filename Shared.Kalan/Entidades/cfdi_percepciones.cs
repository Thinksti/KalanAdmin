using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_percepciones
{
    public int Percepciones_Id { get; set; }

    public decimal? TotalExento { get; set; }

    public decimal? TotalGravado { get; set; }

    public decimal? TotalSueldos { get; set; }

    public int? Nomina_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? TotalSeparacionIndemnizacion { get; set; }
}
