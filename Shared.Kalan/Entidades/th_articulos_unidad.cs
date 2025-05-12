using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_articulos_unidad
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string? ClaveSAT { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
