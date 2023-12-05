using Domain.Models;
using DTO.EvenementDto;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.PaysDto;
using DTO.ParticipantDto;
using Domain.DB;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DBContext _context;
        public PaysController(IUnitOfWork unitOfWork, DBContext dBContext)
        { 

            this.unitOfWork = unitOfWork;
            _context = dBContext;

        }
        [HttpGet]
        public IActionResult Get() {


            return Ok(unitOfWork.Pay.GetAll().Select(x=> new {x.IdPays,x.NomPays}).ToArray());
        }

        [HttpPost]
        public IActionResult CreatePays([FromBody] CreatePaysDto ced)
        {
        
            Pay pays = new Pay{ 
                IdPays=Guid.NewGuid(),
                NomPays=ced.NomPays
                
            };

            unitOfWork.Pay.Add(pays);
            unitOfWork.save();

            return Ok(pays);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult EditPays(Guid id, [FromBody] EditPaysDto esd)

        {
            var existingPays =(Pay)unitOfWork.Pay.GetById(id);

            if (existingPays == null)
            {
                return NotFound();
            }


            existingPays.NomPays = esd.NomPays;





            _context.Pays.Update(existingPays);
            unitOfWork.save();

            return Ok(existingPays);
        }

    }
}
