using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_conciliacion_detalle
{
    public string conciliacion_Id { get; set; } = null!;

    public int Partida { get; set; }

    public int Id_Documento { get; set; }

    public string Documento { get; set; } = null!;

    public bool Ingreso { get; set; }

    public DateTime FechaDocumento { get; set; }

    public string? Comentarios { get; set; }

    public decimal Monto { get; set; }

    public bool Conciliado { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual th_concilacion conciliacion { get; set; } = null!;
}
