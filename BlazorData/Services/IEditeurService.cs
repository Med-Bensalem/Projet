using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Services
{
    public interface IEditeurService
    {
        Task<IEnumerable<Editeur>> GetEditeurs();
        Task<Editeur> CreateEditeur(Editeur newEditeur);
        Task<Editeur> UpdateEditeur(Editeur updatedEditeur);
        Task<Editeur> GetEditeur(int id);
        Task DeleteEditeur(int id);
    }
}
