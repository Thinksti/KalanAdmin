using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_customized
{
    public int customized_Id { get; set; }

    public int? Addenda_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
