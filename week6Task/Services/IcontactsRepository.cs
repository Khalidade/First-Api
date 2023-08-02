using week6Task.Entities;

namespace week6Task.Services
{
    public interface IcontactsRepository
    {
        Task<IEnumerable<Contacts>> GetContactsAsync();
        Task<(IEnumerable<Contacts>, PaginationMetadata)> GetContactsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);

        Task<Contacts> GetContactsAsync  (int contactId);


        Task<bool> ContactExistAsync(int contactId);

        Task AddContactsAsync(Contacts contacts);
        Task <bool> SaveChangesAsync();
        Task DeleteContact(Contacts contacts);
    }
}
