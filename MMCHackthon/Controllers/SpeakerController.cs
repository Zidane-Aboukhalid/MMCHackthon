using Domain.Models;
using DTO.EvenementDto;
<<<<<<< HEAD
using DTO.Speaker;
=======

using DTO.SpeakerDto;
>>>>>>> 68b8efac81bdd9ecb43c7e4a6ecdbf9965e290fe
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SpeakerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        [HttpPost]
        public IActionResult CreateSpeaker([FromBody] CreateSpeakerDto ced)
        {
            Speaker speaker = new Speaker
            {
<<<<<<< HEAD
                SpeakerId = Guid.NewGuid(),
=======
                IdEve = Guid.NewGuid(),
>>>>>>> 68b8efac81bdd9ecb43c7e4a6ecdbf9965e290fe
                SpeakerPhoto = ced.SpeakerPhoto,
                Mct = ced.Mct,
                Mvp = ced.Mvp,
                Biography = ced.Biography
            };


            unitOfWork.Speaker.Add(speaker);
            unitOfWork.save();

            return Ok(speaker);
        }
    }
}