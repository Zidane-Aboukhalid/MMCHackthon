using Domain.Models;
using DTO.EvenementDto;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using DTO.SponsorDTO;
using Domain.DB;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DBContext _context;
        public SponsorController(IUnitOfWork unitOfWork , DBContext context)
        {
            this.unitOfWork = unitOfWork;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateSponsor([FromBody] CreateSponsorDTO ced)
        {
            Sponseur sponsor = new Sponseur
            {

                NomSponseur = ced.NomSponseur,
                ImageUrl = ced.ImageUrl,
            };

            unitOfWork.Sponseur.Add(sponsor);
            unitOfWork.save();

            return Ok(sponsor);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Sponseur.GetAll().Select(x => new { x.NomSponseur, x.ImageUrl }).ToArray());
        }
        [HttpPut("{id:Guid}")]
        public IActionResult EditSponsor(Guid id, [FromBody] EditSponsorDTO esd)
        {
            var existingSponsor =(Sponseur)unitOfWork.Sponseur.GetById(id);

            if (existingSponsor == null)
            {
                return NotFound();
            }


            existingSponsor.NomSponseur = esd.NomSponseur;
            existingSponsor.ImageUrl = esd.ImageUrl;

            _context.Sponseurs.Update(existingSponsor);
            unitOfWork.save();

            return Ok(existingSponsor);
        }
        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteSponsor([FromRoute] Guid id)
        {
            var existingSponsor =(Sponseur)unitOfWork.Sponseur.GetById(id);


            unitOfWork.Sponseur.Remove(existingSponsor);
            unitOfWork.save();

            return Ok(unitOfWork.Sponseur.GetAll().Select(x => new { x.NomSponseur, x.ImageUrl }).ToArray());
        }
    }
}
