using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_retencionesp
{
    public int RetencionesP_Id { get; set; }

    public int? ImpuestosP_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
