using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_acuentaterceros
{
    public string? RfcACuentaTerceros { get; set; }

    public string? NombreACuentaTerceros { get; set; }

    public decimal? RegimenFiscalACuentaTerceros { get; set; }

    public decimal? DomicilioFiscalACuentaTerceros { get; set; }

    public int? Concepto_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
