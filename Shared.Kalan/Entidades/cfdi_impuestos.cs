using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_impuestos
{
    public int? Impuestos_Id { get; set; }

    public int? Concepto_Id { get; set; }

    public decimal? TotalImpuestosTrasladados { get; set; }

    public int? Comprobante_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? TotalImpuestosRetenidos { get; set; }
}
