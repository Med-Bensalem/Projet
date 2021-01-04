using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public interface ICategorieService
    {
        Task<IEnumerable<Categorie>> GetCategories();
        Task<Categorie> CreateCategorie(Categorie newCategorie);
        Task<Categorie> UpdateCategorie(Categorie updatedCategorie);
        Task<Categorie> GetCategorie(int id);
        Task DeleteCategorie(int id);
    }
}
