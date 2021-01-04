using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Pages
{
    public class AuteurListBase : ComponentBase
    {
        [Inject]
        public IAuteurService auteurService { get; set; }
        public IEnumerable<Auteur> Auteurs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Auteurs = (await auteurService.GetAuteurs()).ToList();
        }
    }
}
