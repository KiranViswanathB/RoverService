using RoverService.Models;

namespace RoverService.Service
{
    public interface INasaService
    {
        Task<PhotoDto?> GetPhotos(DateTime earthDate);
    }
}
