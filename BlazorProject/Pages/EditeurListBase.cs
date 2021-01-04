using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Pages
{
    public class EditeurListBase : ComponentBase
    {
        public Editeur Editeur { get; set; } = new Editeur();

        [Inject]
        public IEditeurService editeurService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Editeur> Editeurs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Editeurs = (await editeurService.GetEditeurs()).ToList();
        }
        protected async Task CreateEditeur()
        {
            await editeurService.CreateEditeur(Editeur);
            NavigationManager.NavigateTo("/ListEditeurs");
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/ListEditeurs");
        }


    }
}
