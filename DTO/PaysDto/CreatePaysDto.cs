using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DTO.PaysDto
{
    public class CreatePaysDto
    {
        public string? NomPays { get; set; }

        public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
    }
}
