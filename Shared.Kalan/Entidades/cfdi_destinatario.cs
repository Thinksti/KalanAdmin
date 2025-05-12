using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_destinatario
{
    public Guid? pkUUID { get; set; }

    public int? Destinatario_Id { get; set; }

    public string? NumRegIdTrib { get; set; }

    public string? Nombre { get; set; }

    public int? ComercioExterior_Id { get; set; }
}
