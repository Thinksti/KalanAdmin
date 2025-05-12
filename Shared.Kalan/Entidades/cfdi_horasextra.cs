using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_horasextra
{
    public decimal? Dias { get; set; }

    public decimal? HorasExtra { get; set; }

    public decimal? ImportePagado { get; set; }

    public decimal? TipoHoras { get; set; }

    public int? Percepcion_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
