using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetuserclaims
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual aspnetusers User { get; set; } = null!;
}
