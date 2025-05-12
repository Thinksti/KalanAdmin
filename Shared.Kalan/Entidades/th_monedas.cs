using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_monedas
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_contabilidad_trabajo> th_contabilidad_trabajo { get; set; } = new List<th_contabilidad_trabajo>();

    public virtual ICollection<th_ingresos_complemento_detalle> th_ingresos_complemento_detalle { get; set; } = new List<th_ingresos_complemento_detalle>();

    public virtual ICollection<th_venta_factura> th_venta_factura { get; set; } = new List<th_venta_factura>();
}
