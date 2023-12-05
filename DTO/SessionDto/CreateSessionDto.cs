using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SessionDto
{
    public class CreateSessionDto
    {
        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public string? Lieu { get; set; }

        public Guid? IdEve { get; set; }

    }
}
