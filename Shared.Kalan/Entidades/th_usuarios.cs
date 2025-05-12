using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_usuarios
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public bool? RequiereCambioContrasena { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCrea { get; set; } = null!;

    public DateTime FechaCrea { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public string? UsuarioInhabilita { get; set; }

    public DateTime? FechaInhabilita { get; set; }
}
