using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_cuentascobraraplicaciones
{
    public string Id { get; set; } = null!;

    public string ingreso_Id { get; set; } = null!;

    public string cuentascobrar_Id { get; set; } = null!;

    public string cliente_Id { get; set; } = null!;

    public decimal MontoAplicado { get; set; }

    public DateTime FechaAplicacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual th_clientes cliente { get; set; } = null!;

    public virtual th_cuentascobrar cuentascobrar { get; set; } = null!;

    public virtual th_ingresos ingreso { get; set; } = null!;
}
