using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_facturacion_series
{
    public string Id { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int FolioSiguiente { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
