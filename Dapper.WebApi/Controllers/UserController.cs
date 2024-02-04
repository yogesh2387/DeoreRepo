
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Dapper.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserBusienss userBusienss;
        public UserController(IUnitOfWork unitOfWork, IUserBusienss userBusienss)
        {
            this.unitOfWork = unitOfWork;
            this.userBusienss = userBusienss;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Users.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Users.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {

            var x = userBusienss.ValidateMoblileNo(user.MobileNo);
            var data = await unitOfWork.Users.AddAsync(user);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Users.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var data = await unitOfWork.Users.UpdateAsync(user);
            return Ok(data);
        }
    }
}
