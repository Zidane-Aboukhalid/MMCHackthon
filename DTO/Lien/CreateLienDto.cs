using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Lien
{
    public class CreateLienDto
    {
        public Guid IdLien { get; set; }

        public string? LienType { get; set; }

        public string? Url { get; set; }

        public Guid? SpeakerId { get; set; }
    }
}
