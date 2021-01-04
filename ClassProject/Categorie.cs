using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Designation { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }
         
        public ICollection <Livre> livres { get; set; }
    }
}
