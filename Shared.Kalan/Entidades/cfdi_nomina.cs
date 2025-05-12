using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_nomina
{
    public int Nomina_Id { get; set; }

    public string? FechaFinalPago { get; set; }

    public string? FechaInicialPago { get; set; }

    public string? FechaPago { get; set; }

    public decimal? NumDiasPagados { get; set; }

    public string? TipoNomina { get; set; }

    public decimal? TotalDeducciones { get; set; }

    public decimal? TotalOtrosPagos { get; set; }

    public decimal? TotalPercepciones { get; set; }

    public string? Version { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? Emisor { get; set; }
}
