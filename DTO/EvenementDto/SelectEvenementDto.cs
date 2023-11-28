using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EvenementDto
{
    public class SelectEvenementDto
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

    }
}
