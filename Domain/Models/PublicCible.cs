using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PublicCible
{
    public Guid PublicCibleId { get; set; }

    public string? PublicCibleName { get; set; }

    public Guid? IdEve { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }
}
