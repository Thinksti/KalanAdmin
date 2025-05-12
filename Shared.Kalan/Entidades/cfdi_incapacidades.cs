using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_incapacidades
{
    public int Incapacidades_Id { get; set; }

    public int? Nomina_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
