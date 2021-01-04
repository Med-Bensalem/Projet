using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public interface IEditeurRepository
    {
        Task<IEnumerable<Editeur>> GetEditeurs();
        Task<Editeur> GetEditeur(int editeurId);
        Task<Editeur> AddEditeur(Editeur editeur);
        Task<Editeur> UpdateEditeur(Editeur editeur);
        Task<Editeur> DeleteEditeur(int editeurId);
    }
}
