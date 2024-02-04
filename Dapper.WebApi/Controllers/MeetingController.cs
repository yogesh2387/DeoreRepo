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
    public class MeetingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public MeetingController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Meeting.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Meeting.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Meeting meeting)
        {
            var data = await unitOfWork.Meeting.AddAsync(meeting);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Meetingid)
        {
            var data = await unitOfWork.Meeting.DeleteAsync(Meetingid);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Meeting meeting)
        {
            var data = await unitOfWork.Meeting.UpdateAsync(meeting);
            return Ok(data);
        }
    }
}