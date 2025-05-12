using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_percepcion
{
    public decimal? Clave { get; set; }

    public string? Concepto { get; set; }

    public decimal? ImporteExento { get; set; }

    public decimal? ImporteGravado { get; set; }

    public decimal? TipoPercepcion { get; set; }

    public int? Percepciones_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? Percepcion_Id { get; set; }
}
