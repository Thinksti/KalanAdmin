using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_facturacion_sellos
{
    public Guid Id { get; set; }

    public byte[]? Sello_Cer { get; set; }

    public byte[]? Sello_Key { get; set; }

    public string? Sello_Password { get; set; }

    public DateTime? Sello_Vencimiento { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
