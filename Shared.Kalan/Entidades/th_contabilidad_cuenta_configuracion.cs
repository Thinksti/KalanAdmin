using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_cuenta_configuracion
{
    public string Id { get; set; } = null!;

    public string moneda_Id { get; set; } = null!;

    public bool Segmento1 { get; set; }

    public bool Segmento2 { get; set; }

    public bool Segmento3 { get; set; }

    public bool Segmento4 { get; set; }

    public bool Segmento5 { get; set; }

    public bool Segmento6 { get; set; }

    public int Segmento1Largo { get; set; }

    public int Segmento2Largo { get; set; }

    public int Segmento3Largo { get; set; }

    public int Segmento4Largo { get; set; }

    public int Segmento5Largo { get; set; }

    public int Segmento6Largo { get; set; }

    public int Mayor { get; set; }

    public int Detalle { get; set; }

    public int Costos { get; set; }

    public string? cuentacompra_Id { get; set; }

    public string? cuentaventa_Id { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
