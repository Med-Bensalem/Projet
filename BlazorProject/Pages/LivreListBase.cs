using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Pages
{
    public class LivreListBase : ComponentBase
    {
        [Inject]
        public IlivreService livreService{ get; set; }
        public IEnumerable<Livre> Livres { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Livres = (await livreService.GetLivres()).ToList();
        }
    }
}
