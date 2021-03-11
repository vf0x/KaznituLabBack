using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.ProjectModels;
using KaznituLab.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projService;
        public ProjectController(IProjectService projService)
        {
            _projService = projService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _projService.GetAll();
            return Ok(res);
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var res = _projService.Get(Id);
            return Ok(res);
        }
        [HttpPost("Save")]
        public IActionResult Save(ProjectGetResponseModel model)
        {
            var res = _projService.Save(model);
            return Ok(res);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int Id)
        {
            _projService.Delete(Id);
            return Ok();
        }
    }
}
