using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.WorkModels;
using KaznituLab.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : BaseController
    {
        private readonly IWorkService _workService;
        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _workService.GetAll();
            return Ok(res);
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var res = _workService.Get(Id);
            return Ok(res);
        }
        [HttpPost("Save")]
        public IActionResult Save([FromForm] WorkRequestModel model)
        {
            var res = _workService.Save(model);
            return Ok(res);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _workService.Delete(Id);
            return Ok();
        }
    }
}
