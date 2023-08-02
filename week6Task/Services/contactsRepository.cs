using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using week6Task.DbContexts;
using week6Task.Entities;

namespace week6Task.Services
{
    public class contactsRepository : IcontactsRepository
    {
        private readonly ContactsContexts _context;

        public contactsRepository(ContactsContexts context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Contacts>> GetContactsAsync()
        {
            return await _context.Contacts.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<(IEnumerable<Contacts>, PaginationMetadata)> GetContactsAsync(string name, string searchQuery, int pageNumber, int pageSize)
        {
            


            var collection = _context.Contacts as IQueryable<Contacts>;

            if(!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(x => x.Name == name); 
            }

            if(!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();

                collection = collection.Where(x => x.Name.Contains(searchQuery) || (x.Address != null && x.Address.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetaData = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(x => x.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetaData);

        }

        public async Task<Contacts> GetContactsAsync(int ContactsId)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.ContactsId == ContactsId);
        }

        public async Task<bool> ContactExistAsync(int contactId)
        {
            return await _context.Contacts.AnyAsync(x => x.ContactsId == contactId);
        }

        public async Task AddContactsAsync(Contacts contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0 );
        }
        public async Task DeleteContact(Contacts contact)
        {
            _context.Contacts.Remove(contact);
        }
       
        // Implement other methods for updating and deleting contacts, if applicable
    }
}
