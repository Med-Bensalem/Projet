using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public interface ILivreService
    {
        Task<IEnumerable<Livre>> GetLivres();
        Task<Livre> CreateLivre(Livre newLivre);
        Task<Livre> UpdateLivre(Livre updatedLivre);
        Task<Livre> GetLivre(int id);
        Task DeleteLivre(int id);
    }
}

