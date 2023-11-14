using Domain.Models;
using DTO.EvenementDto;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.PaysDto;
using Domain.Models;
namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PaysController(IUnitOfWork unitOfWork)
        { 
            this.unitOfWork = unitOfWork;

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

    }
}
