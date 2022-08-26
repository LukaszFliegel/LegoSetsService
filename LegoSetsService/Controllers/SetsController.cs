using LegoSetsService.DomainModels;
using LegoSetsService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoSetsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly ISetsServices _setsServices;

        public SetsController(ISetsServices setsServices)
        {
            _setsServices = setsServices;
        }

        [HttpPost]
        public async Task<IActionResult> TrackNewSet(string setNumber)
        {
            var addedSet = await _setsServices.TrackNewSet(setNumber);

            return Ok(addedSet);
        }
    }
}
