using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_timbrefiscaldigital
{
    public string? Version { get; set; }

    public string? UUID { get; set; }

    public string? FechaTimbrado { get; set; }

    public string? RfcProvCertif { get; set; }

    public string? SelloCFD { get; set; }

    public string? NoCertificadoSAT { get; set; }

    public string? SelloSAT { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? Leyenda { get; set; }
}
