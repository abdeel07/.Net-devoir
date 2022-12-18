using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Devoir.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Le champ ID est obligatoire")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le champ name est obligatoire")]
        public string name { get; set; }

        [Required(ErrorMessage = "Le champ type est obligatoire")]
        public string type { get; set; }

        [Required(ErrorMessage = "Le champ email est obligatoire")]
        public float prix { get; set; }

        [Required(ErrorMessage = "Le champ password est obligatoire")]
        public int qstock { get; set; }

        [Required(ErrorMessage = "Le champ dateAjout est obligatoire")]
        public DateTime dateAjout { get; set; }
    }
}