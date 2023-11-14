using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DTO.EvenementDto;
using Domain.Models;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EvenementController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        [HttpPost]
        public IActionResult CreateEvn([FromBody] CreateEvenementDto ced)
        {
            Evenement evenement = new Evenement
            {
                IdEve = Guid.NewGuid(),
                NomEve = ced.NomEve,
                AdressEve = ced.AdressEve,
                DateDebut = ced.DateDebut,
                DateFin = ced.DateFin,
                ImagUrl = ced.ImagUrl,
                DescriptionEve = ced.DescriptionEve,
                IdVille = ced.IdVille,
                NbrPart = ced.NbrPart,
                NbrPlace= ced.NbrPlace,
                TypeEve= ced.TypeEve


            };

            unitOfWork.Evenement.Add(evenement);
            unitOfWork.save();

            return Ok(evenement);
        }
    }
}
