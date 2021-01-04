using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Editeur
    {
        [Key]
        public int EditeurId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string NomEditeur { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Pays { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Adresse { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Telephone { get; set; }

        public ICollection<Livre> livres { get; set; }

    }
}
