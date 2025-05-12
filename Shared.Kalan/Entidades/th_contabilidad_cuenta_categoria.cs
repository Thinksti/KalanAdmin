using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_cuenta_categoria
{
    public string Id { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Segmento { get; set; }

    public int AgrupadorSAT { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_contabilidad_cuenta> th_contabilidad_cuenta { get; set; } = new List<th_contabilidad_cuenta>();
}
