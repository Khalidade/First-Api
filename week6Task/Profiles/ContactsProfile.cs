



using AutoMapper;

namespace week6Task.Profiles
{
    public class ContactsProfile : Profile 
    {
        public ContactsProfile()
        {
            CreateMap<Entities.Contacts, Models.ContactDTO>();
            CreateMap<Models.ContactDTO, Entities.Contacts>();
        }
    }
}
