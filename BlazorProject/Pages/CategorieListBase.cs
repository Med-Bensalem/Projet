using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Pages
{
    public class CategorieListBase : ComponentBase
    {
        public Categorie Categorie { get; set; } = new Categorie();

        [Inject]
        public ICategorieService categorieService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        public IEnumerable<Categorie> Categories { get; set; }
        
        

        protected override async Task OnInitializedAsync()
        {
            Categories = (await categorieService.GetCategories()).ToList();
            
        }
        protected async Task CreateCategorie()
        {
            await categorieService.CreateCategorie(Categorie);
            NavigationManager.NavigateTo("/ListCategories");
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/ListCategories");
        }


    }
}
