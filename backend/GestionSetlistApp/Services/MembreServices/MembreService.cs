using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.MembreRepositories;

namespace GestionSetlistApp.Services.MembreServices
{
    public class MembreService(IMembreRepository repository) : IMembreService
    {
        private readonly IMembreRepository _repository = repository;

        public async Task<IEnumerable<MembreReadDTO>> GetAllAsync()
        {
            IEnumerable<Membre> membres = await _repository.GetAllAsync();
            IEnumerable<MembreReadDTO> membresDTO = membres
            .Select(m => new MembreReadDTO(m.MembreId,
            m.Nom,
            m.Prenom,
            m.Age,
            m.MembreSetlist.Select(ms => ms.SetlistId).ToList(),
            m.Instruments.Select(i => i.InstrumentId).ToList(),
            m.MembreEvenements.Select(me => me.EvenementId).ToList()
            )
            ).ToList();
            return membresDTO;
        }
        public async Task<MembreReadDTO> AddMembreAsync(MembreCreateDTO membreDTO)
        {
            if (membreDTO.DateNaissance > DateTime.Today)
            {
                throw new ArgumentException("La date de naissance ne peut pas être dans le futur.");
            }
            var membre = new Membre
            {
                Nom = membreDTO.Nom,
                Prenom = membreDTO.Prenom,
                DateNaissance = membreDTO.DateNaissance
            };

            membre.CalculerAge();
            await _repository.AddMembreAsync(membre);
            Console.WriteLine($"\n\n\nMembre ajouté avec l'id {membre.MembreId}\n\n\n");
            return new MembreReadDTO(
                membre.MembreId,
                membre.Nom,
                membre.Prenom,
                membre.Age,
                [], [], []
            );
        }

        public async Task<MembreReadDTO> GetMembreAsync(int membreId)
        {
            var membre = await _repository.GetMembreAsync(membreId) ?? throw new KeyNotFoundException();
            return new MembreReadDTO(
                membre.MembreId,
                membre.Nom,
                membre.Prenom,
                membre.Age,
                membre.MembreSetlist.Select(ms => ms.SetlistId).ToList(),
                membre.Instruments.Select(i => i.InstrumentId).ToList(),
                membre.MembreEvenements.Select(me => me.EvenementId).ToList()
            );                 
        }
        public async Task DeleteMembreAsync(int membreId)
        {
            var membre = await _repository.GetMembreAsync(membreId);
            if (membre == null)
            {
                Console.WriteLine("Coucou");
                throw new KeyNotFoundException();
            }
            await _repository.DeleteMembreAsync(membreId);

        }
        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }
    }
}