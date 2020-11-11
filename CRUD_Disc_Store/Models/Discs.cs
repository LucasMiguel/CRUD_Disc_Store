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
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

    }
}
