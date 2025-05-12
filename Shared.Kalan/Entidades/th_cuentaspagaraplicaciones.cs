using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_cuentaspagaraplicaciones
{
    public string Id { get; set; } = null!;

    public string egreso_Id { get; set; } = null!;

    public string cuentaspagar_Id { get; set; } = null!;

    public string proveedor_Id { get; set; } = null!;

    public decimal MontoAplicado { get; set; }

    public DateTime FechaAplicacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual th_cuentaspagar cuentaspagar { get; set; } = null!;

    public virtual th_egresos egreso { get; set; } = null!;

    public virtual th_proveedores proveedor { get; set; } = null!;

    public virtual ICollection<th_ingresos_complemento_detalle> th_ingresos_complemento_detalle { get; set; } = new List<th_ingresos_complemento_detalle>();
}
