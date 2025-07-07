using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.SetlistRepositories;

namespace GestionSetlistApp.Services.SetlistServices
{
    public class SetlistService(ISetlistRepository repository) : ISetlistService
    {
        private readonly ISetlistRepository _repository = repository;
        public async Task<IEnumerable<SetlistReadDTO>> GetAllAsync()
        {
            IEnumerable<Setlist> setlists = await _repository.GetAllAsync();

            IEnumerable<SetlistReadDTO> setlistsDTO = setlists.Select(s => new SetlistReadDTO(
                s.SetlistId,
                s.NomSetlist,
                s.DureeSetlist,
                s.Evenements.Select(e => e.EvenementId).ToList(),
                s.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO(ms.MorceauId, ms.Position)).ToList(),
                s.MembreSetlist.Select(m => m.MembreId).ToList()
            )).ToList();

            return setlistsDTO;
        }

        
    }
}