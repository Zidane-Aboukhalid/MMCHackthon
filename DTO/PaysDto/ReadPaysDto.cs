using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PaysDto
{
    public class ReadPaysDto
    {
        public Guid IdPays { get; set; }
        public string? NomPays { get; set; }
       
    }
}
