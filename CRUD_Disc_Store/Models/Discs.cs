using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Disc_Store.Models
{
    public class Discs
    {
        [Key]
        public int DiscID { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Valor mínimo inválido")]
        [Required(ErrorMessage = "Por favor insira um título")]
        public string Title { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Valor mínimo inválido")]
        [Required(ErrorMessage = "Por favor insira um Artista")]
        public string Author { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Valor mínimo inválido")]
        [Required(ErrorMessage = "Por favor insira um Gênero")]
        public string Genre { get; set; }

    }
}
