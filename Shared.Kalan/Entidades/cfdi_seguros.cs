using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_seguros
{
    public string? AseguraRespCivil { get; set; }

    public string? PolizaRespCivil { get; set; }

    public int? Autotransporte_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? AseguraCarga { get; set; }

    public string? PolizaCarga { get; set; }

    public decimal? PrimaSeguro { get; set; }

    public string? AseguraMedAmbiente { get; set; }

    public decimal? PolizaMedAmbiente { get; set; }
}
