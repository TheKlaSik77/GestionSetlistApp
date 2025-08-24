using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.SetlistRepositories
{
    public class SetlistRepository(GestionSetlistDbContext dbContext) : ISetlistRepository
    {
        private readonly GestionSetlistDbContext _dbcontext = dbContext;
        public async Task<IEnumerable<Setlist>> GetAllAsync()
        {
            return await _dbcontext.Setlists
            .Include(ms => ms.MorceauSetlists)
                .ThenInclude(ms => ms.Morceau)
            .Include(e => e.Evenements)
            .Include(m => m.MembreSetlist)
                .ThenInclude(m => m.Membre)
                .ThenInclude(i => i.Instruments)
                .ThenInclude(i => i.Instrument)
            .ToListAsync();
        }

        public async Task<Setlist?> GetSetlistAsync(int setlistId)
        {
            return await _dbcontext.Setlists
            .Include(ms => ms.MorceauSetlists)
                .ThenInclude(ms => ms.Morceau)
            .Include(e => e.Evenements)
            .Include(m => m.MembreSetlist)
                .ThenInclude(m => m.Membre)
                .ThenInclude(i => i.Instruments)
                .ThenInclude(i => i.Instrument)
            .FirstOrDefaultAsync(s => s.SetlistId == setlistId);
        }

        public async Task<MembreSetlist?> GetMembreToSetlistAsync(int setlistId, int membreId)
        {
            return await _dbcontext.MembreSetlist.FirstOrDefaultAsync(ms => ms.SetlistId == setlistId && ms.MembreId == membreId);
        }

        public async Task<MorceauSetlist?> GetMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            return await _dbcontext.MorceauSetlist.FirstOrDefaultAsync(m => m.SetlistId == setlistId && m.MorceauId == morceauId);
        }

        public async Task<int?> GetMaxPositionSetlistAsync(int setlistId)
        {
            return await _dbcontext.MorceauSetlist.Where(ms => ms.SetlistId == setlistId).MaxAsync(ms => (int?)ms.Position);
        }

        public async Task<Morceau?> GetMorceauAsync(int morceauId)
        {
            return await _dbcontext.Morceaux.FirstOrDefaultAsync(m => m.MorceauId == morceauId);
        }

        public async Task<Membre?> GetMembreAsync(int membreId)
        {
            return await _dbcontext.Membres.FirstOrDefaultAsync(m => m.MembreId == membreId);
        }

        public async Task<int> GetDureeTotaleSetlistAsync(int setlistId)
        {
            return await _dbcontext.MorceauSetlist
                .Where(ms => ms.SetlistId == setlistId)
                .SumAsync(ms => (int?)ms.Morceau.DureeMorceau) ?? 0;
        }

        public async Task AddSetlistAsync(Setlist setlist)
        {
            await _dbcontext.Setlists.AddAsync(setlist);
            await _dbcontext.SaveChangesAsync();
        }


        public async Task AddMorceauToSetlistAsync(MorceauSetlist morceauSetlist)
        {
            await _dbcontext.MorceauSetlist.AddAsync(morceauSetlist);
            await _dbcontext.SaveChangesAsync();   
        }

        public async Task AddMembreToSetlistAsync(MembreSetlist membreSetlist)
        {
            await _dbcontext.MembreSetlist.AddAsync(membreSetlist);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateSetlistAsync(Setlist setlist)
        {
            _dbcontext.Setlists.Update(setlist);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            await _dbcontext.MorceauSetlist.Where(ms => ms.SetlistId == setlistId && ms.MorceauId == morceauId).ExecuteDeleteAsync();
        }

        public async Task DeleteMembreToSetlistAsync(int setlistId, int membreId)
        {
            await _dbcontext.MembreSetlist.Where(ms => ms.SetlistId == setlistId && ms.MembreId == membreId).ExecuteDeleteAsync();
        }

        public async Task DeleteSetlistAsync(int setlistId)
        {
            await _dbcontext.Evenements
            .Where(e => e.SetlistId == setlistId)
            .ExecuteUpdateAsync(setter => setter
                .SetProperty(e => e.SetlistId, e => null));

            await _dbcontext.MorceauSetlist.Where(ms => ms.SetlistId == setlistId).ExecuteDeleteAsync();
            await _dbcontext.MembreSetlist.Where(ms => ms.SetlistId == setlistId).ExecuteDeleteAsync();
            await _dbcontext.Setlists.Where(s => s.SetlistId == setlistId).ExecuteDeleteAsync();

        }
    }
}