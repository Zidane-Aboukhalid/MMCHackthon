using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DTO.ParticipantDto;
using Domain.Models;
using DTO.EvenementDto;


namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public object EditSponsorDTO { get; private set; }

        public ParticipantController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        [HttpPost]
        public IActionResult CreateParticipant([FromBody] CreateParticipantDto ced)
        {
            Participant participant = new Participant
            {
                PublicCibleId = Guid.NewGuid(),
                FullName = ced.FullName,
                Email = ced.Email,
                IdEve = ced.IdEve,
               


            };

            unitOfWork.Participant.Add(participant);
            unitOfWork.save();

            return Ok(participant);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(unitOfWork.Participant.GetAll().Select(x => new { x.PublicCibleId, x.FullName, x.Email, x.IdEve }).ToArray());

           
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteParticipant([FromRoute] Guid id)
        {

            Participant participant = unitOfWork.Participant.Find(id);

            unitOfWork.Participant.Remove(participant);
            unitOfWork.Save();
            // pour affiche all Participant
            return Ok(unitOfWork.Participant.GetAll().Select(x => new { x.PublicCibleId, x.FullName, x.Email, x.IdEve }).ToArray());
        }

        [HttpPut("{id}")]
         public IActionResult EditParticipant(int id, [FromBody] EditParticipantDto esd)

        {
            Participant existingParticipant = unitOfWork.Participant.GetById(id);

            if (existingParticipant == null)
            {
                return NotFound();
            }

            // Mettez à jour les propriétés nécessaires de l'objet Participant
            existingParticipant.FullName = esd.FullName;
            existingParticipant.Email = esd.Email;
            existingParticipant.IdEve = esd.IdEve;


            unitOfWork.Update(existingParticipant);
            unitOfWork.Save();

            return Ok(existingParticipant);
        }
    }
}
