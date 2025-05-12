using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetusertokens
{
    public string UserId { get; set; } = null!;

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }
}
