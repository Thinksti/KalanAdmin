using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_complementoconcepto
{
    public int ComplementoConcepto_Id { get; set; }

    public int? Concepto_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
