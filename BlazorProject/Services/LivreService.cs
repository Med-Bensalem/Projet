using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject.Services
{
    public class LivreService : IlivreService
    {
        private readonly HttpClient httpClient;

        public LivreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Livre>> GetLivres()
        {
            return await httpClient.GetJsonAsync<Livre[]>("api/livres");
        }
        public async Task<Livre> CreateLivre(Livre newLivre)
        {
            return await httpClient.PostJsonAsync<Livre>("api/livres", newLivre);
        }
        public async Task<Livre> UpdateLivre(Livre updatedLivre)
        {
            return await httpClient.PutJsonAsync<Livre>("api/livres", updatedLivre);
        }
        public async Task<Livre> GetLivre(int id)
        {
            return await httpClient.GetJsonAsync<Livre>($"api/livres/{id}");
        }
        public async Task DeleteLivre(int id)
        {
            await httpClient.DeleteAsync($"api/livres/{id}");
        }
    }
}
