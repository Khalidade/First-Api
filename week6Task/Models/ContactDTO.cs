using System.ComponentModel.DataAnnotations;
using week6Task.Entities;

namespace week6Task.Models
{
    public class ContactDTO
    {
        
        public int Id { get; set; }

       
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public long PhoneNumber { get; set; }
       
        public string Twitter { get; set; }
        public string PhotoUrl { get; set; }

    }
}
