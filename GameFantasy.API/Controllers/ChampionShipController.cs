using GameFantasy.Application.Interfaces;
using GameFantasy.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameFantasy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionShipController : ControllerBase
    {
        private readonly IChampionShipService _championShipService;

        public ChampionShipController(IChampionShipService championShipService)
        {
            _championShipService = championShipService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =await _championShipService.GenerateScorePlateAsync();
            return Ok(result);
        }
    }
}
