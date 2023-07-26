using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Services;

namespace Discoteque.Business.Services
{
    public class SongsService : ISongService
    {
        private IUnitOfWork _unitOfWork;

        public SongsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Song> CreateSong(Song song)
        {
            var album = await _unitOfWork.AlbumRepository.FindAsync(song.AlbumId);
            


            if (album != null)
            {
                await _unitOfWork.SongRepository.AddAsync(song);
                await _unitOfWork.SaveAsync();
                return song;
            }
            throw new ArgumentException("Album id not found");
            
        }

        public async Task<List<Song>> CreateSongsFromList(IEnumerable<Song> songs)
        {
            List<Song> addedSongs = new();
            try 
            {
                foreach (var song in songs)
                {
                    var newSong = await CreateSong(song);
                    addedSongs.Add(newSong);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            await _unitOfWork.SaveAsync();
            return addedSongs;
        }

        public async Task<Song> GetById(int id)
        {
            return await _unitOfWork.SongRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            return await _unitOfWork.SongRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumId(int albumId)
        {
            IEnumerable<Song> songs;        
            songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Id.Equals(albumId), x => x.OrderBy(x => x.Id), new Album().GetType().Name);
            return songs;
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumName(string albumName)
        {
            IEnumerable<Song> songs;        
            songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Name.Equals(albumName), x => x.OrderBy(x => x.Id), new Album().GetType().Name);
            return songs;
        }

        public async Task<Song> UpdateSong(Song song)
        {
            // var dbSong = GetById(song.Id);
            // if (dbSong == null) 
            // {
            //     return BadRequest("Song not found.");
            // }

            await _unitOfWork.SongRepository.Update(song);
            await _unitOfWork.SaveAsync();
            return song;
        }
    }
}