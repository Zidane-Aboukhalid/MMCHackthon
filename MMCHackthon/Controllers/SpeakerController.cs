using Domain.Models;
using DTO.EvenementDto;

using DTO.SpeakerDto;
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
                IdEve = Guid.NewGuid(),
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