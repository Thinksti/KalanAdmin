using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_complemento
{
    public int Complemento_Id { get; set; }

    public int? Comprobante_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
