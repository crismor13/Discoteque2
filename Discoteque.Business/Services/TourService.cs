using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TourService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Tour> CreateTour(Tour tour)
        {
            if (tour.Date.Year < 2021)
            {
                throw new ArgumentException("Tour date year must be greater than 2021");
            }

            await _unitOfWork.TourRepository.AddAsync(tour);
            await _unitOfWork.SaveAsync();
            return tour;
        }

        public async Task<Tour> GetById(int id)
        {
            return await _unitOfWork.TourRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Tour>> GetToursAsync()
        {
            return await _unitOfWork.TourRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Tour>> GetToursByArtistId(int albumId)
        {
            IEnumerable<Tour> tours;        
            tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.Artist.Id.Equals(albumId), x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
            return tours;
        }

        public async Task<IEnumerable<Tour>> GetToursByDate(DateOnly tourDate)
        {
            IEnumerable<Tour> tours;        
            tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.Date.Equals(tourDate), x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
            return tours;
        }

        public async Task<Tour> UpdateTour(Tour tour)
        {
            await _unitOfWork.TourRepository.Update(tour);
            await _unitOfWork.SaveAsync();
            return tour;
        }
    }
}