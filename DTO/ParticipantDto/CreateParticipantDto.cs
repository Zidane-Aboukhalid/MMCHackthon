using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ParticipantDto
{
    public class CreateParticipantDto
    {
        public Guid IdParticipant { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public Guid? IdEve { get; set; }
    }
}