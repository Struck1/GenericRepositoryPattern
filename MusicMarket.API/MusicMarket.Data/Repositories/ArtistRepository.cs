using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {


        public ArtistRepository(MusicMarketDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await MusicMarketDbContext.Artists
                 .Include(a => a.Musics)
                 .ToListAsync();
        }

        public async Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return await MusicMarketDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
        private MusicMarketDbContext MusicMarketDbContext
        {
            get { return Context as MusicMarketDbContext; }
        }
    }
}
