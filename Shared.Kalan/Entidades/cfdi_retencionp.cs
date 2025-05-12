using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retencionp
{
    public decimal? ImporteP { get; set; }

    public decimal? ImpuestoP { get; set; }

    public int? RetencionesP_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
