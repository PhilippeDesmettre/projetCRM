using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet.Models
{
    public class Structure
    {
        public int StructureId { get; set; }
        public string RaisonSocial { get; set; }
        public Addresse Addresse { get; set; }
        public List<Contact> ContactsStructures { get; set; }
    }
}