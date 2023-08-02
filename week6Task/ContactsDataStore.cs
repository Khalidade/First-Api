using week6Task.Models;

namespace week6Task
{
    public class ContactsDataStore
    {
        public List<ContactDTO> contacts {  get; set; }

        public static ContactsDataStore Current { get; } = new ContactsDataStore();

        public ContactsDataStore() 
        { 
            contacts = new List<ContactDTO>()
            {
                new ContactDTO()
                {
                    Id = 1,
                    Name = "Daniel Adeleke",
                    Address = "Ibadan",
                    PhoneNumber = 08023932313,

                },

                new ContactDTO()
                {
                    Id = 2,
                    Name = "Jonah Hill",
                    Address = "USA",
                    PhoneNumber = 08023932313,

                },

                new ContactDTO()
                {
                    Id = 3,
                    Name = "Jamie Foxx",
                    Address = "Arabia",
                    PhoneNumber = 08023932313,

                }

            };
        }  
    }
}
