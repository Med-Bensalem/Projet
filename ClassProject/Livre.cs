using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Livre
    {
        [Key]
        public int LivreId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Titre { get; set; }
        public int NbPages { get; set; }
        public DateTime DateEdition { get; set; }
        public int NbExemplaires { get; set; }
        public float Prix { get; set; }
        public string Isbn { get; set; }

        public int EditeurId { get; set; }
        public Editeur Editeur;

        public int CategorieId { get; set; }
        public Categorie Categorie;

        public ICollection<Auteur> auteurs { get; set; }
    }
}
