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
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Report.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.Report.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Reports report)
        {
            var data = await unitOfWork.Report.AddAsync(report);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int ReportID)
        {
            var data = await unitOfWork.Report.DeleteAsync(ReportID);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Reports report)
        {
            var data = await unitOfWork.Report.UpdateAsync(report);
            return Ok(data);
        }
    }
}