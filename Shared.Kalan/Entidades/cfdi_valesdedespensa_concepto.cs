using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_valesdedespensa_concepto
{
    public decimal? identificador { get; set; }

    public string? fecha { get; set; }

    public string? rfc { get; set; }

    public string? curp { get; set; }

    public string? nombre { get; set; }

    public decimal? numSeguridadSocial { get; set; }

    public decimal? importe { get; set; }

    public int? valesdedespensa_Conceptos_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
