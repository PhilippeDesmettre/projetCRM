using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet.Models
{
    public class Addresse
    {
        

        public int Id { get; set; }
        public string NumeroRue { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public int CodePostal { get; set; }
        public string Telephone { get; set; }
        public int? Contact_id { get; set; }
        public int? Structure_id { get; set; }
        public Structure structure { get; set; }

        public Addresse(int id, string numeroRue, string rue, string ville, int codePostal, string telephone)
        {
            Id = id;
            NumeroRue = numeroRue;
            Rue = rue;
            Ville = ville;
            CodePostal = codePostal;
            Telephone = telephone;
        }
        public Addresse()
        {

        }
    }
}