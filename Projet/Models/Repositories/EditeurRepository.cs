using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public class EditeurRepository : IEditeurRepository
    {
        private readonly AppDbContext appDbContext ;
        public EditeurRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ;
        }
        public async Task<Editeur> AddEditeur(Editeur editeur)
        {
            var result = await appDbContext.Editeurs.AddAsync(editeur);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Editeur> DeleteEditeur(int editeurId)
        {
            var result = await appDbContext.Editeurs.FirstOrDefaultAsync(e => e.EditeurId == editeurId);
            if(result != null)
            {
                appDbContext.Editeurs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Editeur> GetEditeur(int editeurId)
        {
            return await appDbContext.Editeurs.FirstOrDefaultAsync(e => e.EditeurId == editeurId);
        }

        public async Task<IEnumerable<Editeur>> GetEditeurs()
        {
            return await appDbContext.Editeurs.ToListAsync();
        }

        public async Task<Editeur> UpdateEditeur(Editeur editeur)
        {
            var result = await appDbContext.Editeurs.FirstOrDefaultAsync(e => e.EditeurId == editeur.EditeurId);
            if(result != null)
            {
                result.NomEditeur = editeur.NomEditeur;
                result.Pays = editeur.Pays;
                result.Adresse = editeur.Adresse;
                result.Telephone = editeur.Telephone;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
