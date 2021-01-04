using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class EditeurService : IEditeurService
    {
        private readonly HttpClient httpClient;

        public EditeurService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Editeur>> GetEditeurs()
        {
            return await httpClient.GetJsonAsync<Editeur[]>("api/editeurs");
        }
        public async Task<Editeur> CreateEditeur(Editeur newEditeur)
        {
            return await httpClient.PostJsonAsync<Editeur>("api/editeurs", newEditeur);
        }
        public async Task<Editeur> UpdateEditeur(Editeur updatedEditeur)
        {
            return await httpClient.PutJsonAsync<Editeur>("api/editeurs", updatedEditeur);
        }
        public async Task<Editeur> GetEditeur(int id)
        {
            return await httpClient.GetJsonAsync<Editeur>($"api/editeurs/{id}");
        }
        public async Task DeleteEditeur(int id)
        {
            await httpClient.DeleteAsync($"api/editeurs/{id}");
        }
    }
}
