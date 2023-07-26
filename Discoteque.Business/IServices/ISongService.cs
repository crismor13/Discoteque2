using Discoteque.Data.Models;

namespace Discoteque.Business.IServices
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetSongsAsync();
        Task<IEnumerable<Song>> GetSongsByAlbumId(int albumId);
        Task<IEnumerable<Song>> GetSongsByAlbumName(string albumName);
        Task<Song> GetById(int id);
        Task<Song> CreateSong(Song song);
        Task<List<Song>> CreateSongsFromList(IEnumerable<Song> songs);
        Task<Song> UpdateSong(Song song);
    }
}