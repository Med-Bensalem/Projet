using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public class LivreRepository : ILivreRepository
    {
        private readonly AppDbContext appDbContext ;
        public LivreRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Livre> AddLivre(Livre livre)
        {
            var result = await appDbContext.Livres.AddAsync(livre);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Livre> DeleteLivre(int livreId)
        {
            var result = await appDbContext.Livres.SingleOrDefaultAsync(e => e.LivreId == livreId);
            if(result != null)
            {
                appDbContext.Livres.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Livre> GetLivre(int livreId)
        {
            return await appDbContext.Livres.SingleOrDefaultAsync(e => e.LivreId == livreId);
        }

        public async Task<IEnumerable<Livre>> GetLivres()
        {
            return await appDbContext.Livres.Include(e => e.Editeur).Include(e => e.Categorie).ToListAsync();
        }

        public async Task<Livre> UpdateLivre(Livre livre)
        {
            var result = await appDbContext.Livres.SingleOrDefaultAsync(e => e.LivreId == livre.LivreId);
            if (result != null)
            {
                result.Titre = livre.Titre;
                result.NbPages = livre.NbPages;
                result.DateEdition = livre.DateEdition;
                result.NbExemplaires = livre.NbExemplaires;
                result.Prix = livre.Prix;
                result.Isbn = livre.Isbn;

                await appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
