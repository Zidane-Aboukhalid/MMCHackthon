using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Session
{
    public Guid IdSession { get; set; }

    public DateTime? DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public string? Lieu { get; set; }

    public Guid? IdEve { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }
}
