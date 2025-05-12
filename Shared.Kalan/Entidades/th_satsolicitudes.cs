using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_satsolicitudes
{
    public string IdSolicitud { get; set; } = null!;

    public string CodEstatus { get; set; } = null!;

    public string? Mensaje { get; set; }

    public string TipoSolicitud { get; set; } = null!;

    public string RfcSolicitante { get; set; } = null!;

    public DateTime FechaInicial { get; set; }

    public DateTime FechaFinal { get; set; }

    public string? RfcEmisor { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
