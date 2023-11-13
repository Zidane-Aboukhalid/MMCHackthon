using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Speaker
{
    public Guid SpeakerId { get; set; }

    public Guid? FichierId { get; set; }

    public Guid? IdEve { get; set; }

    public byte[]? SpeakerPhoto { get; set; }

    public bool? Mct { get; set; }

    public bool? Mvp { get; set; }

    public string? Biography { get; set; }

    public virtual Fichier? Fichier { get; set; }

    public virtual Evenement? IdEveNavigation { get; set; }

    public virtual ICollection<Lien> Liens { get; set; } = new List<Lien>();
}
