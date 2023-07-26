using Discoteque.Data.Models;
using Discoteque.Business.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Discoteque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("GetSongs")]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _songService.GetSongsAsync();
            return Ok(songs);
        }

        [HttpGet]
        [Route("GetSongById")]
        public async Task<IActionResult> GetById(int id)
        {
            var song = await _songService.GetById(id);
            return Ok(song);
        }

        [HttpGet]
        [Route("GetSongsByAlbumId")]
        public async Task<IActionResult> GetSongsByAlbumId(int albumId)
        {
            var songs = await _songService.GetSongsByAlbumId(albumId);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "There was no albums found in this genre");
        }

        [HttpGet]
        [Route("GetSongsByAlbumName")]
        public async Task<IActionResult> GetSongsByAlbumName(string albumName)
        {
            var songs = await _songService.GetSongsByAlbumName(albumName);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "There was no albums found in this genre");
        }


        [HttpPost]
        [Route("CreateSong")]
        public async Task<IActionResult> CreateSongAsync(Song newSong)
        {
            try
            {
                var result = await _songService.CreateSong(newSong);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateSongsFromList")]
        public async Task<IActionResult> CreateSongsFromList(IEnumerable<Song> songs)
        {
            try
            {
                var result = await _songService.CreateSongsFromList(songs);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSongAsync")]
        public async Task<IActionResult> UpdateSongAsync(Song song)
        {
            try
            {
                var result = await _songService.UpdateSong(song);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                throw new Exception("Efe como dicen los jóvenes", ex);
            }
            
        }
    }
}
