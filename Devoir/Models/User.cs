using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Devoir.Models
{
    public class User
    {
        [Required(ErrorMessage = "Le champ ID est obligatoire")]
        public int CIN { get; set; }

        [Required(ErrorMessage = "Le champ name est obligatoire")]
        public string name { get; set; }

        public string type { get; set; }

        [Required(ErrorMessage = "Le champ email est obligatoire")]
        public string email { get; set; }

        [Required(ErrorMessage = "Le champ password est obligatoire")]
        public string password { get; set; }
    }
}