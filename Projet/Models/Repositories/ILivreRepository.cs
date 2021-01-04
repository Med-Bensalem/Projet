using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public interface ILivreRepository
    {
        Task<IEnumerable<Livre>> GetLivres();
        Task<Livre> GetLivre(int livreId);
        Task<Livre> AddLivre(Livre livre);
        Task<Livre> UpdateLivre(Livre livre);
        Task<Livre> DeleteLivre(int livreId);
    }
}
