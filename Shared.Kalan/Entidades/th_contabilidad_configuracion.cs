using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_configuracion
{
    public string Id { get; set; } = null!;

    public string? RFC { get; set; }

    public byte[]? Fiel_Cer { get; set; }

    public byte[]? Fiel_Key { get; set; }

    public string? Fiel_Password { get; set; }

    public DateTime? Fiel_Vencimiento { get; set; }

    public string? FormatoCC { get; set; }

    public int? SegmentoCostos { get; set; }

    public int? SegmentoMayor { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
