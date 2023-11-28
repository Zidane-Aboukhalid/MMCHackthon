using Domain.Models;
using DTO.EvenementDto;
using DTO.PublicCibleDto;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.PublicCibleDto;
using Domain.Models;
using DTO.EvenementDto;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicCibleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public object EditSponsorDTO { get; private set; }

        public PublicCibleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        [HttpPost]
        public IActionResult CreatePublicCible([FromBody] CreatePublicCibleDto ced)
        {
            PublicCible publicCible = new PublicCible
            {
                PublicCibleId = Guid.NewGuid(),
                PublicCibleName = ced.PublicCibleName,
               
            };

            unitOfWork.PublicCible.Add(publicCible);
            unitOfWork.save();

            return Ok(publicCible);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.PublicCible.GetAll().Select(x => new { x.PublicCibleId, x.PublicCibleName }).ToArray());


        }

    }

     
}
