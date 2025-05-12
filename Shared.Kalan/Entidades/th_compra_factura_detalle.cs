using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_compra_factura_detalle
{
    public string Id { get; set; } = null!;

    public string factura_Id { get; set; } = null!;

    public int Partida { get; set; }

    public string articulo_Id { get; set; } = null!;

    public decimal Unitario { get; set; }

    public decimal Cantidad { get; set; }

    public decimal Impuesto { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Total { get; set; }

    public string? planimpuestos_Id { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual th_articulos articulo { get; set; } = null!;

    public virtual th_compra_factura factura { get; set; } = null!;

    public virtual th_plan_impuestos? planimpuestos { get; set; }
}
