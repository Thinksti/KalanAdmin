using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_porcuentadeterceros
{
    public int PorCuentadeTerceros_Id { get; set; }

    public string? version { get; set; }

    public string? rfc { get; set; }

    public string? nombre { get; set; }

    public int? ComplementoConcepto_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
