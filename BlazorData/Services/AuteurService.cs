using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorProject.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly HttpClient httpClient;

        public AuteurService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Auteur>> GetAuteurs()
        {
            return await httpClient.GetJsonAsync<Auteur[]>("api/auteurs");
        }
        public async Task<Auteur> CreateAuteur(Auteur newAuteur)
        {
            return await httpClient.PostJsonAsync<Auteur>("api/auteurs", newAuteur);
        }
        public async Task<Auteur> UpdateAuteur(Auteur updatedAuteur)
        {
            return await httpClient.PutJsonAsync<Auteur>("api/auteurs", updatedAuteur);
        }
        public async Task<Auteur> GetAuteur(int id)
        {
            return await httpClient.GetJsonAsync<Auteur>($"api/auteurs/{id}");
        }
        public async Task DeleteAuteur(int id)
        {
            await httpClient.DeleteAsync($"api/auteurs/{id}");
        }

        
    }
}
