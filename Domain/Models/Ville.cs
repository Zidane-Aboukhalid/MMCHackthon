using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Ville
{
    public Guid IdVille { get; set; }

    public string? NomVille { get; set; }

    public Guid? IdPays { get; set; }

    public virtual ICollection<Evenement> Evenements { get; set; } = new List<Evenement>();

    public virtual Pay? IdPaysNavigation { get; set; }
}
