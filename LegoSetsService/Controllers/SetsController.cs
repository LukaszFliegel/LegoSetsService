using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LegoSetsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        public SetsController()
        {

        }

        [HttpPost]
        public IEnumerable<WeatherForecast> TrackNewSet(string setNumber)
        {
            
        }
    }
}
