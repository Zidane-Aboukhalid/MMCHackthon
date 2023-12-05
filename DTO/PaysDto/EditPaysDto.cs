using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PaysDto
{
    public class EditPaysDto
    {
        public string? NomPays { get; set; }

        public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
    }
}
