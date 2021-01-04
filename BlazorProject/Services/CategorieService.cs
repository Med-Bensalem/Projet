using Microsoft.AspNetCore.Components;
using Projet.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly HttpClient httpClient;

        public CategorieService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Categorie>> GetCategories()
        {
            return await httpClient.GetJsonAsync<Categorie[]>("api/categories");
        }
        public async Task<Categorie> CreateCategorie(Categorie newCategorie)
        {
            return await httpClient.PostJsonAsync<Categorie>("api/categories", newCategorie);
        }
        public async Task<Categorie> UpdateCategorie(Categorie updatedCategorie)
        {
            return await httpClient.PutJsonAsync<Categorie>("api/categories", updatedCategorie);
        }
        public async Task<Categorie> GetCategorie(int id)
        {
            return await httpClient.GetJsonAsync<Categorie>($"api/categories/{id}");
        }
        public async Task DeleteCategorie(int id)
        {
            await httpClient.DeleteAsync($"api/categories/{id}");
        }
    }
}
