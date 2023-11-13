using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Evenement
{
    public Guid IdEve { get; set; }

    public string? NomEve { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string? DescriptionEve { get; set; }

    public string? ImagUrl { get; set; }

    public string? AdressEve { get; set; }

    public string? TypeEve { get; set; }

    public Guid? IdVille { get; set; }

    public int? NbrPlace { get; set; }

    public int? NbrPart { get; set; }

    public virtual ICollection<Categorie> Categories { get; set; } = new List<Categorie>();

    public virtual ICollection<EvenementSponseur> EvenementSponseurs { get; set; } = new List<EvenementSponseur>();

    public virtual Ville? IdVilleNavigation { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<PublicCible> PublicCibles { get; set; } = new List<PublicCible>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
