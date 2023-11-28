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
            
            if (ced.DateDebut < ced.DateFin && ced.NbrPart>=ced.NbrPlace)
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
                    NbrPlace = ced.NbrPlace,
                    TypeEve = ced.TypeEve


                };

                unitOfWork.Evenement.Add(evenement);
                unitOfWork.save();

                return Ok(evenement);
            }
            else
            {
                return BadRequest("check date or check nber Place ");
            }
           
        }

        [HttpGet]
        public IActionResult GetAll()
        {
               var listSelectEvenementDto = new List<SelectEvenementDto>();
         
            foreach (Evenement ev in unitOfWork.Evenement.GetAll())
            {
                SelectEvenementDto selectEvenementDto = new SelectEvenementDto
                {
                    IdEve= ev.IdEve,
                    NomEve= ev.NomEve,
                    DateDebut= ev.DateDebut,
                    DateFin= ev.DateFin,
                    ImagUrl = ev.ImagUrl,
                    DescriptionEve= ev.DescriptionEve,
                    IdVille= ev.IdVille,
                    AdressEve = ev.AdressEve,
                    TypeEve = ev.TypeEve,
                    NbrPart = ev.NbrPart,
                    NbrPlace= ev.NbrPlace
                    
                };
                listSelectEvenementDto.Add(selectEvenementDto);
            }

            return Ok(listSelectEvenementDto.ToArray());
        }

        [HttpDelete]
        [Route("id:Guid")]

        public IActionResult DeleteEnv(Guid id)
        {
            var environment =(Evenement)unitOfWork.Evenement.GetById(id);

            if (environment == null)
                return null;

            unitOfWork.Evenement.Remove(environment);
            unitOfWork.save();

            return Ok("delete is done");

        }
        
    }
}
