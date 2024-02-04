using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Services.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Services.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Services service)
        {
            var data = await unitOfWork.Services.AddAsync(service);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int ServiceId)
        {
            var data = await unitOfWork.Services.DeleteAsync(ServiceId);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Services service)
        {
            var data = await unitOfWork.Services.UpdateAsync(service);
            return Ok(data);
        }
    }
}