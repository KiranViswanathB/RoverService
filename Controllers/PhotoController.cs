using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoverService.Models;
using RoverService.Service;

namespace RoverService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private INasaService _nasaService;
        public PhotoController(INasaService nasaService)
        {
            _nasaService = nasaService;
        }

        [HttpGet()]
        public async Task<ActionResult<PhotoDto?>> GetPhotos(DateTime earthDate)
        {
            return await _nasaService.GetPhotos(earthDate);
        }
    }
}
