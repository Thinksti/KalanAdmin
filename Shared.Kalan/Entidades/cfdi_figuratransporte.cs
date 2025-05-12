using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_figuratransporte
{
    public int FiguraTransporte_Id { get; set; }

    public int? CartaPorte_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
