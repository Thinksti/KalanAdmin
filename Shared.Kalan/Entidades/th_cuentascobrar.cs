using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_cuentascobrar
{
    public string Id { get; set; } = null!;

    public string cliente_Id { get; set; } = null!;

    public string Factura { get; set; } = null!;

    public string? UUID { get; set; }

    public decimal Original { get; set; }

    public decimal Disponible { get; set; }

    public string metodopago_Id { get; set; } = null!;

    public DateTime Fecha { get; set; }

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

    public virtual th_clientes cliente { get; set; } = null!;

    public virtual th_metodopago metodopago { get; set; } = null!;

    public virtual ICollection<th_cuentascobraraplicaciones> th_cuentascobraraplicaciones { get; set; } = new List<th_cuentascobraraplicaciones>();

    public virtual th_venta_factura? th_venta_factura { get; set; }
}
