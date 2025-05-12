using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_valesdedespensa
{
    public int ValesDeDespensa_Id { get; set; }

    public string? tipoOperacion { get; set; }

    public decimal? numeroDeCuenta { get; set; }

    public decimal? total { get; set; }

    public string? version { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? registroPatronal { get; set; }
}
