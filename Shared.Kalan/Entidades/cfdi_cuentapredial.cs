using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cuentapredial
{
    public string? Numero { get; set; }

    public int? Concepto_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
