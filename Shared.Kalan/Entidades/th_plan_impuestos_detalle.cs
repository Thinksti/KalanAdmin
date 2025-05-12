using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_plan_impuestos_detalle
{
    public string Id { get; set; } = null!;

    public string plan_impuestos_id { get; set; } = null!;

    public string impuestos_id { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_impuestos impuestos { get; set; } = null!;

    public virtual th_plan_impuestos plan_impuestos { get; set; } = null!;
}
