using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly AppDbContext appDbContext ;
        public CategorieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext ;
        }
        public async Task<Categorie> AddCategorie(Categorie categorie)
        {
            var result = await appDbContext.Categories.AddAsync(categorie);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Categorie> DeleteCategorie(int categorieId)
        {
            var result = await appDbContext.Categories.FirstOrDefaultAsync(e => e.CategorieId == categorieId);
            if(result != null)
            {
                appDbContext.Categories.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Categorie> GetCategorie(int categorieId)
        {
            return await appDbContext.Categories.FirstOrDefaultAsync(e => e.CategorieId == categorieId);
        }

        public async Task<IEnumerable<Categorie>> GetCategories()
        {
            return await appDbContext.Categories.ToListAsync();
        }

        public async Task<Categorie> UpdateCategorie(Categorie categorie)
        {
            var result = await appDbContext.Categories.FirstOrDefaultAsync(e => e.CategorieId == categorie.CategorieId);
            if(result != null)
            {
                result.Description = categorie.Description;
                result.Designation = categorie.Designation;

                await appDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
