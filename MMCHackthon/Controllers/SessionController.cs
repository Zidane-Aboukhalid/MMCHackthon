using Domain.DB;
using Domain.Models;
using DTO.SessionDto;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly DBContext dBContext;

        public SessionController(IUnitOfWork unitOfWork, DBContext dBContext)
        {
            this.unitOfWork = unitOfWork;
            this.dBContext = dBContext;

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(unitOfWork.Session.GetAll());
        
        }


        [HttpPost]
        public IActionResult CreatSession([FromBody] CreateSessionDto createSessionDTO)
        { 
            if (createSessionDTO == null)
            {
                return BadRequest("Session not Exist");
            }
            Session session = new Session
            {
                IdSession=Guid.NewGuid(),
                IdEve= createSessionDTO.IdEve,
                DateDebut=createSessionDTO.DateDebut,
                DateFin=createSessionDTO.DateFin
            };

            unitOfWork.Session.Add(session);
            return Ok(session);
        }


        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult EditSession([FromRoute] Guid id , [FromBody] CreateSessionDto createSessionDto )
        {
            
            return Ok();
        }
    }
}
