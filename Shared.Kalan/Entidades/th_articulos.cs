using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_articulos
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string tipo_id { get; set; } = null!;

    public int OpImpCompra { get; set; }

    public int OpImpVenta { get; set; }

    public string? ImpPlanCompra_id { get; set; }

    public string? ImpPlanVenta_id { get; set; }

    public string? cuentacontable_id { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public string? catalogoproductosat_Id { get; set; }

    public string unidad_Id { get; set; } = null!;

    public virtual th_plan_impuestos? ImpPlanCompra { get; set; }

    public virtual th_plan_impuestos? ImpPlanVenta { get; set; }

    public virtual th_catproductosat? catalogoproductosat { get; set; }

    public virtual ICollection<th_articulos_proveedor> th_articulos_proveedor { get; set; } = new List<th_articulos_proveedor>();

    public virtual ICollection<th_compra_factura_detalle> th_compra_factura_detalle { get; set; } = new List<th_compra_factura_detalle>();

    public virtual ICollection<th_venta_factura_detalle> th_venta_factura_detalle { get; set; } = new List<th_venta_factura_detalle>();

    public virtual th_articulos_tipos tipo { get; set; } = null!;
}
