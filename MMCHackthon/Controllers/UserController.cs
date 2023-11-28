using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MMCHackthon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(unitOfWork.User.GetAll()); 
        }


        [HttpGet]
        [Route ("{id:Guid}")]
        public IActionResult GetPerson([FromRoute]Guid id)
        {
            var User = unitOfWork.User.Find(x=> x.IdUser==id);

            return Ok(User);
        }


        [HttpPost]

        public IActionResult addUser([FromBody]User user)
        {
            if (user == null) {
                return BadRequest("user is not exist");

            }
            unitOfWork.User.Add(user);
            unitOfWork.save();
            return Ok();

        }
    }
}
