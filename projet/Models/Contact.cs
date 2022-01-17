using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Addresse addresse { get; set; }
        public List<Structure> Structures { get; set; }
    }
}