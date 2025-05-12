using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_sat_control
{
    public string UUID { get; set; } = null!;

    public string? Ruta { get; set; }

    public bool Existe { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public DateTime? FechaDescarga { get; set; }
}
