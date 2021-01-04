using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Auteur
    {
        [Key]
        public int AuteurId { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Prenom { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nom { get; set; }
        public string Biographie { get; set; }

        public ICollection<Livre> livres { get; set; }
    }
}
