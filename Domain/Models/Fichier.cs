using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Fichier
{
    public Guid FichierId { get; set; }

    public string? FichierUrl { get; set; }

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
