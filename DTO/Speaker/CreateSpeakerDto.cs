using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Speaker
{
    public class CreateSpeakerDto
    {
        public Guid SpeakerId { get; set; }

        public Guid? FichierId { get; set; }

        public Guid? IdEve { get; set; }

        public byte[]? SpeakerPhoto { get; set; }

        public bool? Mct { get; set; }

        public bool? Mvp { get; set; }

        public string? Biography { get; set; }
        public List<CreateLinkDto> Lien { get; set; }
    }

    public class CreateLinkDto
    {
        public Guid IdLien { get; set; }

        public string? LienType { get; set; }

        public string? Url { get; set; }

        public Guid? SpeakerId { get; set; }
    }
}
