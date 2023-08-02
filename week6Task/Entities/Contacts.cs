using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace week6Task.Entities
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactsId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Address { get; set; }

        public long PhoneNumber { get; set; }
       

        public string Twitter { get; set; }
        public string PhotoUrl { get; internal set; }

        public Contacts(string name)
        {
            Name = name;
        }


    }
}
