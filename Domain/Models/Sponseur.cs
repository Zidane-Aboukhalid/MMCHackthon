using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sponseur
{
    public Guid IdSponsor { get; set; }

    public string? NomSponseur { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<EvenementSponseur> EvenementSponseurs { get; set; } = new List<EvenementSponseur>();
}
