using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public Guid IdUser { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? MotPass { get; set; }

    public int? Role { get; set; }
}
