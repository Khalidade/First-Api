using Microsoft.EntityFrameworkCore;
using week6Task.Entities;
using week6Task.Models;

namespace week6Task.DbContexts
{
    public class ContactsContexts : DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }

        public ContactsContexts(DbContextOptions<ContactsContexts> options) : base(options)
        {
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().HasData(
                new Contacts("Khalid Adeleke")
                {
                    ContactsId = 1,
                    Name = "Khalid",
                    Address = "lekki",
                    Twitter = "senkou",
                    PhoneNumber = 8023932313,
                    PhotoUrl = "img.jpg",
                },


                 new Contacts("James Patrick")
                 {
                     ContactsId= 2,
                     Name = "james",
                     Address = "Ibadan",
                     Twitter = "kiroii",
                     PhoneNumber = 8023932313,
                    PhotoUrl = "img.jpg",
                 },


                  new Contacts("Javier Bardem")
                  {
                      ContactsId = 3,
                      Name = "Javier",
                      Address = "Abuja",
                      Twitter = "Bgard",
                      PhoneNumber = 8023932313,
                      PhotoUrl = "img.jpg",
                  },
                   new Contacts("David Beckham")
                   {
                      ContactsId = 4,
                       Name = "David",
                       Address = "Ondo",
                       Twitter = "davido",
                       PhoneNumber = 8023932313,
                      PhotoUrl = "img.jpg",
                   }

                );



            base.OnModelCreating(modelBuilder); 
        }
    }
}
