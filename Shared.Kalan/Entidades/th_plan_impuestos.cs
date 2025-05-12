using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_plan_impuestos
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public bool Ventas { get; set; }

    public bool Compras { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_articulos> th_articulosImpPlanCompra { get; set; } = new List<th_articulos>();

    public virtual ICollection<th_articulos> th_articulosImpPlanVenta { get; set; } = new List<th_articulos>();

    public virtual ICollection<th_clientes> th_clientes { get; set; } = new List<th_clientes>();

    public virtual ICollection<th_compra_factura_detalle> th_compra_factura_detalle { get; set; } = new List<th_compra_factura_detalle>();

    public virtual ICollection<th_plan_impuestos_detalle> th_plan_impuestos_detalle { get; set; } = new List<th_plan_impuestos_detalle>();

    public virtual ICollection<th_proveedores> th_proveedores { get; set; } = new List<th_proveedores>();

    public virtual ICollection<th_venta_factura_detalle> th_venta_factura_detalle { get; set; } = new List<th_venta_factura_detalle>();
}
