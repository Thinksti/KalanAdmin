using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_ingresos
{
    public string Id { get; set; } = null!;

    public int Ingreso { get; set; }

    public decimal Original { get; set; }

    public decimal Disponible { get; set; }

    public string bancos_id { get; set; } = null!;

    public string? formapago_id { get; set; }

    public string cliente_Id { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public bool? Conciliado { get; set; }

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

    public string? ingresos_origen_id { get; set; }

    public virtual th_bancos bancos { get; set; } = null!;

    public virtual th_clientes cliente { get; set; } = null!;

    public virtual th_formapago? formapago { get; set; }

    public virtual th_ingresos_origen? ingresos_origen { get; set; }

    public virtual ICollection<th_cuentascobraraplicaciones> th_cuentascobraraplicaciones { get; set; } = new List<th_cuentascobraraplicaciones>();

    public virtual th_tiposcambio tipocambio { get; set; } = null!;
}
