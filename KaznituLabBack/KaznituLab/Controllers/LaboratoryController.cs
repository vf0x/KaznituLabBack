using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.Laboratory;
using KaznituLab.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : BaseController
    {
        private readonly ILaboratoryService _labService;
        public LaboratoryController(ILaboratoryService labService)
        {
            _labService = labService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _labService.GetAll();
            return Ok(res);
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var res = _labService.Get(Id);
            return Ok(res);
        }
        [HttpPost("Save")]
        public IActionResult Save([FromForm] LaboratoryGetRequesetModel model)
        {
            var res = _labService.SaveLaboratory(model);
            return Ok(res);
        }
        [HttpPost("SaveTest")]
        public IActionResult Save(LaboratoryDataRequesetModel model)
        {
            return Ok();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _labService.Delete(Id);
            return Ok();
        }
    }
}
