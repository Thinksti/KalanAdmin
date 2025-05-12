using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_impuestos
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public string IdSAT { get; set; } = null!;

    public string? cuentacontable_id { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_plan_impuestos_detalle> th_plan_impuestos_detalle { get; set; } = new List<th_plan_impuestos_detalle>();
}
