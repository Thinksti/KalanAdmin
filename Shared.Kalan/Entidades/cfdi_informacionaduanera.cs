using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_informacionaduanera
{
    public string? NumeroPedimento { get; set; }

    public int? Concepto_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? Parte_Id { get; set; }
}
