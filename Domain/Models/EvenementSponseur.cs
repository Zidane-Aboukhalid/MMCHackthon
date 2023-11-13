using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class EvenementSponseur
{
    public Guid IdEveSpo { get; set; }

    public Guid? IdSponsor { get; set; }

    public Guid? IdEve { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }

    public virtual Sponseur? IdSponsorNavigation { get; set; }
}
