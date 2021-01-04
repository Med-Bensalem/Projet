using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Services
{
    public interface IAuteurService
    {
        Task<IEnumerable<Auteur>> GetAuteurs();
        Task<Auteur> CreateAuteur(Auteur newAuteur);
        Task<Auteur> UpdateAuteur(Auteur updatedAuteur);
        Task<Auteur> GetAuteur(int id);
        Task DeleteAuteur(int id);
    }
}
