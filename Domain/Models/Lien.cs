using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Lien
{
    public Guid IdLien { get; set; }

    public string? LienType { get; set; }

    public string? Url { get; set; }

    public Guid? SpeakerId { get; set; }

    public virtual Speaker? Speaker { get; set; }
}
