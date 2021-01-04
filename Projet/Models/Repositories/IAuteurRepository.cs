using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public interface IAuteurRepository
    {
        Task<IEnumerable<Auteur>> GetAuteurs();
        Task<Auteur> GetAuteur(int auteurId);
        Task<Auteur> AddAuteur(Auteur auteur);
        Task<Auteur> UpdateAuteur(Auteur auteur);
        Task<Auteur> DeleteAuteur(int auteurId);
    }
}
