using Discoteque.Data.Models;

namespace Discoteque.Business.IServices
{
    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetToursAsync();
        Task<IEnumerable<Tour>> GetToursByArtistId(int albumId);
        Task<IEnumerable<Tour>> GetToursByDate(DateOnly tourDate);    
        Task<Tour> GetById(int id);
        Task<Tour> CreateTour(Tour tour);
        Task<Tour> UpdateTour(Tour tour);
    }
}