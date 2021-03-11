using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.Entity;
using KaznituLab.Models.EquipmentModels;
using KaznituLab.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService _equpmentService;
        public EquipmentController(IEquipmentService equpmentService)
        {
            _equpmentService = equpmentService;
        }
        [HttpPost("Save")]
        public IActionResult Save([FromForm] EquipmentGetRequestModel model)
        {
            var res = _equpmentService.SaveEquipment(model);
            return Ok(res);
        }
        [HttpPost("SaveTest")]
        public IActionResult SaveTest([FromBody]EquipmentViewGetModel model)
        {
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _equpmentService.GetAll();
            return Ok(res);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _equpmentService.Delete(Id);
            return Ok();
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var res = _equpmentService.Get(Id);
            return Ok(res);
        }
    }
}
