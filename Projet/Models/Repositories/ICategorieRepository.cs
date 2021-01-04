using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public interface ICategorieRepository
    {
        Task<IEnumerable<Categorie>> GetCategories();
        Task<Categorie> GetCategorie(int categorieId);
        Task<Categorie> AddCategorie(Categorie categorie);
        Task<Categorie> UpdateCategorie(Categorie categorie);
        Task<Categorie> DeleteCategorie(int categorieId);
    }
}
