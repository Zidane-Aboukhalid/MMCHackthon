using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Pay
{
    public Guid IdPays { get; set; }

    public string? NomPays { get; set; }

    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
