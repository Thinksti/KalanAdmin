using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_terceros_impuestos
{
    public int terceros_Impuestos_Id { get; set; }

    public int? PorCuentadeTerceros_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
