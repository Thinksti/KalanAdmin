using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cfdirelacionados
{
    public int CfdiRelacionados_Id { get; set; }

    public string? TipoRelacion { get; set; }

    public int? Comprobante_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
