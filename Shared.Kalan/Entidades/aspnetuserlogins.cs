using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetuserlogins
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual aspnetusers User { get; set; } = null!;
}
