using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_satsolicitudrespuesta
{
    public string Id { get; set; } = null!;

    public string IdSolicitud { get; set; } = null!;

    public string CodEstatus { get; set; } = null!;

    public string CodigoEstatusSolicitud { get; set; } = null!;

    public int EstadoSolicitud { get; set; }

    public string IdPaquetes { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public int NumeroCFDIs { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
