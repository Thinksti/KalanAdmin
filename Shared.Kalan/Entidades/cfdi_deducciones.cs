using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_deducciones
{
    public int Deducciones_Id { get; set; }

    public decimal? TotalImpuestosRetenidos { get; set; }

    public decimal? TotalOtrasDeducciones { get; set; }

    public int? Nomina_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
