using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetusers
{
    public string Id { get; set; } = null!;

    public string? ConcurrencyStamp { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEndDateUtc { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime? LockoutEnd { get; set; }

    public string? NormalizedEmail { get; set; }

    public string? NormalizedUserName { get; set; }

    public virtual ICollection<aspnetuserclaims> aspnetuserclaims { get; set; } = new List<aspnetuserclaims>();

    public virtual ICollection<aspnetuserlogins> aspnetuserlogins { get; set; } = new List<aspnetuserlogins>();

    public virtual ICollection<aspnetroles> Role { get; set; } = new List<aspnetroles>();
}
