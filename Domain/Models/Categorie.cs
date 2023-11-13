using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Categorie
{
    public Guid IdCategorie { get; set; }

    public Guid? IdEve { get; set; }

    public string? NameCategorie { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }
}
