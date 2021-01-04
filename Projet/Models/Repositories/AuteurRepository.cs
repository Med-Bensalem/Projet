using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public class AuteurRepository : IAuteurRepository
    {
        private readonly AppDbContext appDbContext ;

        public AuteurRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ;
        }
        public async Task<Auteur> AddAuteur(Auteur auteur)
        {
            var result = await appDbContext.Auteurs.AddAsync(auteur);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Auteur> DeleteAuteur(int auteurId)
        {
            var result = await appDbContext.Auteurs.FirstOrDefaultAsync(e => e.AuteurId == auteurId);
            if(result != null)
            {
                appDbContext.Auteurs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Auteur> GetAuteur(int auteurId)
        {
            return await appDbContext.Auteurs.FirstOrDefaultAsync(e => e.AuteurId == auteurId);
        }

        public async Task<IEnumerable<Auteur>> GetAuteurs()
        {
            return await appDbContext.Auteurs.ToListAsync();
        }

        public async Task<Auteur> UpdateAuteur(Auteur auteur)
        {
            var result = await appDbContext.Auteurs.FirstOrDefaultAsync(e => e.AuteurId == auteur.AuteurId);

            if(result != null)
            {
                result.Prenom = auteur.Prenom;
                result.Nom = auteur.Nom;
                result.Biographie = auteur.Biographie;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
