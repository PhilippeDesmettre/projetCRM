using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace projet.Models
{
    public class DAL
    {

        string strcon = ConfigurationManager.ConnectionStrings["EntrepriseeConnection"].ConnectionString;


        public IEnumerable<Contact> GetContacts()
        {
            List<Contact> ContactList = new List<Contact>();
            string queryString = "select ContactId,Prenom,Nom from dbo.contact;";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Contact contact = new Contact();
                    contact.ContactId = Convert.ToInt32(dataReader["ContactId"].ToString());
                    contact.Prenom = dataReader["Prenom"].ToString();
                    contact.Nom = dataReader["Nom"].ToString();
                    ;
                    
                   

                    ContactList.Add(contact);
                }
                connection.Close();
                return ContactList;
            }


        }
        public IEnumerable<Structure> GetStructures()
        {
            List<Structure> StructureList = new List<Structure>();
            string queryString = "select StructureId,RaisonSocial from dbo.Structure;";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Structure structure = new Structure();
                    structure.StructureId = Convert.ToInt32(dataReader["StructureId"].ToString());
                    structure.RaisonSocial = dataReader["RaisonSocial"].ToString();
                    
                    



                    StructureList.Add(structure);
                }
                connection.Close();
                return StructureList;
            }


        }

        public IEnumerable<Structure> GetContactStructures(int ContactId)
        {
            List<Structure> StructureList = new List<Structure>();
            string queryString = $"select s.StructureId, RaisonSocial from  Structure s join ContactStructure c on s.StructureId = c.StructureId join Contact co on co.ContactId = c.ContactId where c.contactId = {ContactId}; ";

            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Structure structure = new Structure();
                    structure.StructureId = Convert.ToInt32(dataReader["StructureId"].ToString());
                    structure.RaisonSocial = dataReader["RaisonSocial"].ToString();

                    



                    StructureList.Add(structure);
                }
                connection.Close();
                return StructureList;
            }

            
        }

        public Addresse GetAddressByStructureId(int Id)
        {
            Addresse addresse = new Addresse();
            string queryString = $"select AddressId,NumeroRue,Ville,CodePostal,Telephone,Rue from address where Id_Structure= {Id};  ";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Addresse AddresseByContact = new Addresse();
                    AddresseByContact.Id = Convert.ToInt32(dataReader["AddressId"].ToString());
                    AddresseByContact.NumeroRue = dataReader["NumeroRue"].ToString();
                    AddresseByContact.Rue = dataReader["Rue"].ToString();
                    AddresseByContact.Ville = dataReader["Ville"].ToString();
                    AddresseByContact.CodePostal = Convert.ToInt32(dataReader["CodePostal"].ToString());
                    AddresseByContact.Telephone = dataReader["Telephone"].ToString();

                    addresse = AddresseByContact;

                }
                connection.Close();
                return addresse;
            }
        }

        public Contact GetAddressId(Addresse addresse)
        {
            Contact ContactFroUpdate = new Contact();
            string queryString = $"select Id where NumeroRue='{ addresse.NumeroRue}' and Ville='{addresse.Ville} and CodePostal='{addresse.CodePostal}' ;";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Contact ContactByID = new Contact();
                    ContactByID.ContactId = Convert.ToInt32(dataReader["Id"].ToString());
                    ContactByID.Prenom = dataReader["Prenom"].ToString();
                    ContactByID.Nom = dataReader["Nom"].ToString();
                    
                    ContactFroUpdate = ContactByID;

                }
                connection.Close();
                return ContactFroUpdate;
            }
        }

        public Addresse GetAddressByContactId(int Id)
        {
            Addresse ContactAddreess = new Addresse();
            string queryString = $"select AddressId,NumeroRue,Ville,CodePostal,Telephone,Rue from address where id_Contact= {Id};  ";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Addresse AddresseByContact = new Addresse();
                    AddresseByContact.Id = Convert.ToInt32(dataReader["AddressId"].ToString());
                    AddresseByContact.NumeroRue = dataReader["NumeroRue"].ToString();
                    AddresseByContact.Rue = dataReader["Rue"].ToString();
                    AddresseByContact.Ville = dataReader["Ville"].ToString();
                    AddresseByContact.CodePostal = Convert.ToInt32(dataReader["CodePostal"].ToString());
                    AddresseByContact.Telephone = dataReader["Telephone"].ToString();
                    ContactAddreess = AddresseByContact;

                }
                connection.Close();
                return ContactAddreess;
            }
        }

        public Contact GetContactById(int? Contactid)
        {
            Contact ContactFroUpdate = new Contact();
            string queryString = $"select ContactId,Prenom,Nom from dbo.contact where ContactId={Contactid};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Contact ContactByID = new Contact();
                    ContactByID.ContactId = Convert.ToInt32(dataReader["ContactId"].ToString());
                    ContactByID.Prenom = dataReader["Prenom"].ToString();
                    ContactByID.Nom = dataReader["Nom"].ToString();
                    
                    ContactFroUpdate = ContactByID;

                }
                connection.Close();
                return ContactFroUpdate;
            }
        }

        public Structure GetStructureById(int StructureId)
        {
            Structure structure = new Structure();
            string queryString = $"select StructureId,RaisonSocial from Structure where StructureId={StructureId};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Structure structureForId = new Structure();
                    structureForId.StructureId = Convert.ToInt32(dataReader["StructureId"].ToString());
                    structureForId.RaisonSocial = dataReader["RaisonSocial"].ToString();
                   

                    structure = structureForId;

                }
                connection.Close();
                return structure;
            }
        }

        public int GetId(Contact contact)
        {
            Contact ContactFroUpdate = new Contact();
            string queryString = $"select ContactId,Prenom,Nom from dbo.contact where Prenom='{contact.Prenom}' and Nom='{contact.Nom}';";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Contact ContactByID = new Contact();
                    ContactByID.ContactId = Convert.ToInt32(dataReader["ContactId"].ToString());
                    ContactByID.Prenom = dataReader["Prenom"].ToString();
                    ContactByID.Nom = dataReader["Nom"].ToString();
                   /* ContactByID.IdAdresse = null; /*Convert.ToInt32(dataReader["AdresseId"].ToString());**/
                    ContactFroUpdate = ContactByID;

                }
                connection.Close();
                return contact.ContactId;
            }
        }


        public Contact CreateContact(Contact contact)
        {
            Contact ContactUpdateAdd = new Contact();
            string queryString = $"INSERT INTO contact (Prenom,Nom) VALUES ( '{contact.Prenom}', '{contact.Nom}');";
            
            string queryString2 = $"select ContactId,Prenom,Nom from dbo.contact where Prenom='{contact.Prenom}' and Nom='{contact.Nom}';";

            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                


                connection.Close();
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                connection.Open();
                

                SqlDataReader dataReader = command2.ExecuteReader();
                while (dataReader.Read())
                {

                    Contact ContactByID = new Contact();
                    ContactByID.ContactId = Convert.ToInt32(dataReader["ContactId"].ToString());
                    ContactByID.Prenom = dataReader["Prenom"].ToString();
                    ContactByID.Nom = dataReader["Nom"].ToString();
                    //ContactByID.IdAdresse = Convert.ToInt32(dataReader["AdresseId"].ToString());
                    ContactUpdateAdd = ContactByID;

                }
                connection.Close();
                return ContactUpdateAdd;
            }


        

            
        }
        public Structure CreateStructure(Structure structure)
        {
            Structure StructureAdd = new Structure();
            string queryString = $"INSERT INTO Structure (RaisonSocial) VALUES ( '{structure.RaisonSocial}');SELECT SCOPE_IDENTITY();";
            int IdStructure=0;
            

            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                int Id= Convert.ToInt32(command.ExecuteScalar());
                IdStructure = Id;
                Addresse addresse1 = new Addresse();


                connection.Close();
                string queryString2 = $"Insert into Address (NumeroRue,Rue,Ville,CodePostal,Telephone,id_Structure) VALUES ({structure.Addresse.NumeroRue},'{structure.Addresse.Rue}','{structure.Addresse.Ville}',{structure.Addresse.CodePostal},'{structure.Addresse.Telephone}',{IdStructure}) ; SELECT SCOPE_IDENTITY();";
                SqlCommand command2 = new SqlCommand(queryString2, connection);
                connection.Open();
                
                int IdAddresse = Convert.ToInt32(command2.ExecuteScalar());

                connection.Close();
                string queryString3 = $"select StructureId,RaisonSocial from Structure where StructureId={Id};";

                SqlCommand command3 = new SqlCommand(queryString3, connection);
                connection.Open();
                SqlDataReader dataReader = command3.ExecuteReader();
                while (dataReader.Read())
                {

                    Structure StructureById = new Structure();
                    StructureById.StructureId = Convert.ToInt32(dataReader["StructureId"].ToString());
                    StructureById.RaisonSocial = dataReader["RaisonSocial"].ToString();

                    StructureAdd = StructureById;

                }
                connection.Close();

                string queryString4 = $"select AddressId,NumeroRue,Rue,Ville,CodePostal,Telephone,id_Structure from Address where id_structure={Id};";
                SqlCommand command4 = new SqlCommand(queryString4, connection);
                connection.Open();
                SqlDataReader dataReader1 = command4.ExecuteReader();
                while(dataReader1.Read())
                {

                    Addresse addresse = new Addresse();
                    addresse.Id = Convert.ToInt32(dataReader1["AddressId"].ToString());
                    addresse.NumeroRue=dataReader1["NumeroRue"].ToString();
                    addresse.Rue = dataReader1["Rue"].ToString();
                    addresse.Ville = dataReader1["Ville"].ToString();
                    addresse.Telephone = dataReader1["Telephone"].ToString();
                    addresse.CodePostal = Convert.ToInt32(dataReader1["CodePostal"].ToString());
                    addresse.Structure_id = Convert.ToInt32(dataReader1["id_Structure"].ToString());
                    
                    addresse1 = addresse;

                }
                
                StructureAdd.Addresse = addresse1;
                connection.Close();
                return StructureAdd;
            }
        }
        public void CreateAddresseForContact(Addresse addresse, int Id)
        {

            string queryString = $"INSERT INTO address (NumeroRue,Rue,Ville,CodePostal,Telephone,id_Contact) values ('{addresse.NumeroRue}','{addresse.Rue}','{addresse.Ville}',{addresse.CodePostal},'{addresse.Telephone}',{Id})";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();

                //int Id = Convert.ToInt32(command.ExecuteScalar());

                
                connection.Close();
                
            }

            

        }
        public void UpdateContact(Contact contact)
        {
            string queryString = $"update contact set Nom='{contact.Nom}', Prenom='{contact.Prenom}' where ContactId={contact.ContactId};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                connection.Close();

            }
        }

        public void UpdateStructure(Structure structure)
        {
            string queryString = $"update structure set RaisonSocial={structure.StructureId};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                connection.Close();

            }
        }

  

        public void Delete(int ContactId)
        {
            string queryString = $"delete contact where ContactId={ContactId};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                connection.Close();

            }
        }
        public void DeleteStruct(int StructureId)
        {
            string queryString = $"delete structure where StructureId={StructureId};";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                connection.Close();

            }
        }

        public void ContactStructure(int Idcontact, int IdStructure)
        {

            string queryString = $"insert into ContactStructure (ContactId,StructureId) values ({Idcontact},{IdStructure}) ";
            using (SqlConnection connection = new SqlConnection(
                   strcon))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();


                connection.Close();

            }

        }


    }
}