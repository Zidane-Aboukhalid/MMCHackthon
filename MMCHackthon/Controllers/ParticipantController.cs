using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DTO.ParticipantDto;
using Domain.Models;
using DTO.EvenementDto;
using Domain.DB;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DBContext _context;


        public ParticipantController(IUnitOfWork unitOfWork, DBContext dBContext)
        {

            this._context = dBContext;
            this.unitOfWork = unitOfWork;

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var ListPart = unitOfWork.Participant.GetAll().Where(x => x.IdEve == id);

            //Console.WriteLine(ListPart.Count);
            if(ListPart == null)
            {
                return BadRequest("Evenement is not exist");
            }


            return Ok(ListPart.Select(x=> new { x.IdParticipant, x.FullName , x.Email }).ToArray());


        }
        [HttpPost]
        public IActionResult CreateParticipant([FromBody] CreateParticipantDto ced)
        {
            Participant participant = new Participant
            {
                IdParticipant = Guid.NewGuid(),
                FullName = ced.FullName,
                Email = ced.Email,
                IdEve = ced.IdEve,



            };

            unitOfWork.Participant.Add(participant);
            unitOfWork.save();

            return Ok(participant);
        }


        [HttpPut("{id:Guid}")]
        public IActionResult EditParticipant(Guid id, [FromBody] EditParticipantDto esd)

        {
            var existingParticipant =(Participant) unitOfWork.Participant.GetById(id);

            if (existingParticipant == null)
            {
                return NotFound();
            }

            // Mettez à jour les propriétés nécessaires de l'objet Participant
            existingParticipant.FullName = esd.FullName;
            existingParticipant.Email = esd.Email;
            existingParticipant.IdEve = esd.IdEve;


            _context.Participants.Update(existingParticipant);
            unitOfWork.save();

            return Ok(existingParticipant);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteParticipant([FromRoute] Guid id)
        {

            var participant = (Participant)unitOfWork.Participant.Find(x => x.IdParticipant == id);

            unitOfWork.Participant.Remove(participant); 
            unitOfWork.save();
            // pour affiche all Participant
            return Ok(unitOfWork.Participant.GetAll().Select(x => new { x.IdParticipant, x.FullName, x.Email, x.IdEve }).ToArray());
        }
    }
}