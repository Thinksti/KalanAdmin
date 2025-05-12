using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_emisor
{
    public string? Rfc { get; set; }

    public string? Nombre { get; set; }

    public string? RegimenFiscal { get; set; }

    public int? Comprobante_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? RegistroPatronal { get; set; }

    public string? RfcPatronOrigen { get; set; }

    public string? Nomina_Id { get; set; }

    public string? Emisor_Id { get; set; }

    public string? ComercioExterior_Id { get; set; }
}
