using Discoteque.Data.Models;
using Discoteque.Business.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Discoteque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService TourService)
        {
            _tourService = TourService;
        }

        [HttpGet]
        [Route("GetTours")]
        public async Task<IActionResult> GetTours()
        {
            var tours = await _tourService.GetToursAsync();
            return Ok(tours);
        }

        [HttpGet]
        [Route("GetTourById")]
        public async Task<IActionResult> GetById(int id)
        {
            var tour = await _tourService.GetById(id);
            return Ok(tour);
        }

        [HttpGet]
        [Route("GetToursByArtistId")]
        public async Task<IActionResult> GetToursByArtistId(int artistId)
        {
            var songs = await _tourService.GetToursByArtistId(artistId);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "There were not tours found");
        }

        [HttpGet]
        [Route("GetToursByDate")]
        public async Task<IActionResult> GetToursByDate(DateOnly date)
        {
            var tours = await _tourService.GetToursByDate(date);
            return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "There were not tours found with this date");
        }


        [HttpPost]
        [Route("CreateTour")]
        public async Task<IActionResult> CreateTourAsync(Tour newTour)
        {

            try
            {
                var result = await _tourService.CreateTour(newTour);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateTourAsync")]
        public async Task<IActionResult> UpdateTourAsync(Tour tour)
        {
            try
            {
                var result = await _tourService.UpdateTour(tour);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            
        }
    }
}