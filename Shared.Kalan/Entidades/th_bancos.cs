using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_bancos
{
    public string Id { get; set; } = null!;

    public string Chequera { get; set; } = null!;

    public bool CajaChica { get; set; }

    public string Banco { get; set; } = null!;

    public string Cuenta { get; set; } = null!;

    public decimal Saldo { get; set; }

    public string? cuentacontable_id { get; set; }

    public string moneda_Id { get; set; } = null!;

    public bool Activo { get; set; }

    public decimal SaldoUltimaConciliacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public DateTime FechaUltimaConciliacion { get; set; }

    public virtual ICollection<th_concilacion> th_concilacion { get; set; } = new List<th_concilacion>();

    public virtual ICollection<th_egresos> th_egresos { get; set; } = new List<th_egresos>();

    public virtual ICollection<th_ingresos> th_ingresos { get; set; } = new List<th_ingresos>();
}
