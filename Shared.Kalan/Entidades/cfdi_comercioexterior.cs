using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_comercioexterior
{
    public Guid? pkUUID { get; set; }

    public int? ComercioExterior_Id { get; set; }

    public string? Version { get; set; }

    public string? ClaveDePedimento { get; set; }

    public string? CertificadoOrigen { get; set; }

    public string? Incoterm { get; set; }

    public string? Observaciones { get; set; }

    public string? TipoCambioUSD { get; set; }

    public string? TotalUSD { get; set; }

    public int? Complemento_Id { get; set; }
}
