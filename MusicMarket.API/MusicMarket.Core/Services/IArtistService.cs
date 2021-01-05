using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtist();

        Task<Artist> GetArtistById(int id);

        Task<Artist> CreateArtist(Artist newArtist);


        Task UpdateArtist(Artist artistListToBeUpdate, Artist artist);

        Task DeleteArtist(Artist artist);
    }
}
