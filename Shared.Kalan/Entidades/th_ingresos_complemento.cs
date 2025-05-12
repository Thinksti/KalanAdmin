using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_ingresos_complemento
{
    public string Id { get; set; } = null!;

    public string ingreso_id { get; set; } = null!;

    public string UUID { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public decimal Monto { get; set; }

    public string moneda_id { get; set; } = null!;

    public string tipocambio_id { get; set; } = null!;

    public string Folio { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<th_ingresos_complemento_detalle> th_ingresos_complemento_detalle { get; set; } = new List<th_ingresos_complemento_detalle>();
}
