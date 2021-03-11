using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFData.HrEntity;
using KaznituLab.Models;
using KaznituLab.Models.Types;
using KaznituLab.Services.Interfaces.Dictionary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaznituLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : BaseController
    {
        private IDictionaryService _dicService;
        public DictionaryController(IDictionaryService dicService)
        {
            _dicService = dicService;
        }
        [HttpGet("GetDict")]
        public List<DictionaryModel> GetDictionary(DictionaryType type)
        {
            return _dicService.GetDictionary(type);
        }
    }
}
