using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetreportes
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Stored { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
