using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_incapacidad
{
    public decimal? DiasIncapacidad { get; set; }

    public decimal? TipoIncapacidad { get; set; }

    public int? Incapacidades_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? ImporteMonetario { get; set; }
}
