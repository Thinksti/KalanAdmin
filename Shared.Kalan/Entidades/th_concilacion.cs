using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_concilacion
{
    public string Id { get; set; } = null!;

    public string banco_Id { get; set; } = null!;

    public DateTime FechaInicial { get; set; }

    public DateTime FechaFinal { get; set; }

    public decimal SaldoBanco { get; set; }

    public decimal Diferencia { get; set; }

    public bool Terminada { get; set; }

    public string? Justificacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_bancos banco { get; set; } = null!;

    public virtual ICollection<th_conciliacion_detalle> th_conciliacion_detalle { get; set; } = new List<th_conciliacion_detalle>();
}
