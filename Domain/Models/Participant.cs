using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Participant
{
    public Guid IdParticipant { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public Guid? IdEve { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }
}
