using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projet.Models;

namespace projet.Controllers
{
    public class ContactController : Controller
    {
        DAL ContactDal = new DAL();
        List<Contact> ContactsList = new List<Contact>();
        
        List<Addresse> addresses = new List<Addresse>();

        public ActionResult Index()
        {

            
            return View();
        }
        public ActionResult GetAllContact()
        {

            List<Contact> conList = new List<Contact>();
            conList = ContactDal.GetContacts().ToList();
            ContactsList = conList;
            return View(ContactsList);
        }
        public ActionResult GetAllStructures()
        {

            List<Structure> StrucList = new List<Structure>();
            StrucList = ContactDal.GetStructures().ToList();
            
            return View(StrucList);
        }
        public ActionResult CreateStructure()
        {



            return View();
        }
        [HttpPost]
        public ActionResult CreateStructure(Structure structure)
        {
            
            structure =ContactDal.CreateStructure(structure);
            Addresse addresse = new Addresse();
            addresse.Id = structure.Addresse.Id;
            addresse.NumeroRue = structure.Addresse.NumeroRue;
            addresse.Rue = structure.Addresse.Rue;
            addresse.Ville = structure.Addresse.Ville;
            addresse.CodePostal = structure.Addresse.CodePostal;
            addresse.Telephone = structure.Addresse.Telephone;
            addresse.structure = structure;
            addresse.Structure_id = structure.StructureId;
            addresses.Add(addresse);
            ModelState.Clear();

            return View();
        }
        public ActionResult Create()
        {
            List<Structure> StructuresList = new List<Structure>();
            StructuresList = ContactDal.GetStructures().ToList();

            ViewBag.Structures = StructuresList;
            return View();
        }

     
        [HttpPost]
        public ActionResult CreateAddresse(Addresse addresse, string Message)
        {
            
            int IdContact; 
            IdContact = Convert.ToInt32(Message);
            ContactDal.CreateAddresseForContact(addresse,IdContact);
            Contact contact = new Contact();
            contact = ContactDal.GetContactById(IdContact);

            

            //ContactDal.UpdateContactAddress(IdContact, IdAddresse);

            return View("Index");
        }

        [HttpGet]
        public ActionResult CreateAddresse(Contact contact)
        {
            ViewBag.IdContact = contact.ContactId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact, int? structure)
        {
            Contact contactWithId = new Contact();
            contactWithId = ContactDal.CreateContact(contact);
            if (structure!=null)
            {
                Structure structure1 = ContactDal.GetStructureById(Convert.ToInt32(structure));
                //contactWithId.Structures.Add(structure1);
                ContactDal.ContactStructure(contactWithId.ContactId, Convert.ToInt32(structure));
            };
            ModelState.Clear();
            ViewBag.IdContact = contactWithId.ContactId;
            contact.ContactId = ViewBag.IdContact;
            
            return RedirectToAction("CreateAddresse",contact);
        }


        
       public ActionResult Update(int id)
        {
            int c = id;
            Contact ContactById = ContactDal.GetContactById(id);
           return View(ContactById);
        }

        public ActionResult UpdateStructure(int id)
        {
            int c = id;
            Structure StructuretById = ContactDal.GetStructureById(id);
            return View(StructuretById);
        }

        [HttpPost]
        public ActionResult UpdateStructure(Structure structure)
        {

            ContactDal.UpdateStructure(structure);
          
            List<Structure> rec = new List<Structure>();
            rec = ContactDal.GetStructures().ToList(); ;

            return View("GetAllStructures", rec);
        }

        public ActionResult Details(int id)
        {
            int c = id;
            Addresse addresse = ContactDal.GetAddressByContactId(id);
            List<Structure> structures = ContactDal.GetContactStructures(id).ToList();
            ViewBag.Structures = structures;
            return View(addresse);
        }
        public ActionResult DetailsStruct(int Id)
        {
            
            Addresse addresse = ContactDal.GetAddressByStructureId(Id);

            return View("Details",addresse); ;
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            ContactDal.UpdateContact(contact);
            List<Contact> rec = new List<Contact>();
            rec = ContactDal.GetContacts().ToList(); 
            
            return View("GetAllContact", rec);
        }

        public ActionResult Delete(int id)
        {
            int c = id;
            ContactDal.Delete(id);
            List<Contact> rec = new List<Contact>();
            rec = ContactDal.GetContacts().ToList(); ;
            
            return View("GetAllContact",rec);
            
        }
        public ActionResult DeleteStruct(int id)
        {
            int c = id;
            ContactDal.DeleteStruct(id);
            List<Structure> rec = new List<Structure>();
            rec = ContactDal.GetStructures().ToList() ;

            return View("GetAllStructures", rec);

        }

    }
}