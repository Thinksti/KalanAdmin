using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_insteducativas
{
    public string? version { get; set; }

    public string? nombreAlumno { get; set; }

    public string? CURP { get; set; }

    public string? nivelEducativo { get; set; }

    public string? autRVOE { get; set; }

    public string? rfcPago { get; set; }

    public int? ComplementoConcepto_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
