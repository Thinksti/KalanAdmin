using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_venta_factura
{
    public string Id { get; set; } = null!;

    public string cliente_id { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public string? UUID { get; set; }

    public DateTime Fecha { get; set; }

    public decimal SubTotal { get; set; }

    public decimal MontoImpuestos { get; set; }

    public decimal Total { get; set; }

    public string metodopago_Id { get; set; } = null!;

    public string condiciones_id { get; set; } = null!;

    public string? Observaciones { get; set; }

    public string moneda_Id { get; set; } = null!;

    public string tipocambio_Id { get; set; } = null!;

    public string? asiento_Id { get; set; }

    public string? asientocancelado_Id { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public string? SucursalEntrega { get; set; }

    public string? OrdenCompra { get; set; }

    public string? RutaXML { get; set; }

    public string? RutaPDF { get; set; }

    public string? RutaAcuse { get; set; }

    public string formapago_Id { get; set; } = null!;

    public virtual th_cuentascobrar IdNavigation { get; set; } = null!;

    public virtual th_clientes cliente { get; set; } = null!;

    public virtual th_condicionescredito condiciones { get; set; } = null!;

    public virtual th_metodopago metodopago { get; set; } = null!;

    public virtual th_monedas moneda { get; set; } = null!;

    public virtual ICollection<th_ingresos_complemento_detalle> th_ingresos_complemento_detalle { get; set; } = new List<th_ingresos_complemento_detalle>();

    public virtual ICollection<th_venta_factura_detalle> th_venta_factura_detalle { get; set; } = new List<th_venta_factura_detalle>();

    public virtual th_tiposcambio tipocambio { get; set; } = null!;
}
