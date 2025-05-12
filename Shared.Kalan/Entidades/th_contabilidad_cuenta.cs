using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_cuenta
{
    public string Id { get; set; } = null!;

    public string? Segmento1 { get; set; }

    public string? Segmento2 { get; set; }

    public string? Segmento3 { get; set; }

    public string? Segmento4 { get; set; }

    public string? Segmento5 { get; set; }

    public string? Segmento6 { get; set; }

    public string CuentaContable { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string categoria_id { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_contabilidad_cuenta_categoria categoria { get; set; } = null!;

    public virtual ICollection<th_contabilidad_trabajo_detalle> th_contabilidad_trabajo_detalle { get; set; } = new List<th_contabilidad_trabajo_detalle>();
}
