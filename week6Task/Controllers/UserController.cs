using Microsoft.AspNetCore.Mvc;
using week6Task.Models;
using System.Linq;
using week6Task.Services;
using AutoMapper;
using week6Task.Entities;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace week6Task.Controllers
{
    [ApiController]
    [Authorize(Policy = "UserPolicy")]
    [Route("api/user/contacts")]
    public class UserController : ControllerBase
    {
        private readonly IcontactsRepository _contactsRepository;

        private readonly IMapper _mapper;

        const int maxContactsPageSize = 20;

        public UserController(IcontactsRepository contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository ?? throw new Exception(nameof(contactsRepository));
            _mapper = mapper ?? throw new Exception(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetMyContacts(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxContactsPageSize)
            {
                pageSize = maxContactsPageSize;
            }
            // You may need to modify this method to fetch contacts related to the authenticated user.
            // For example, you can retrieve contacts belonging to the user based on their ID or any other identifier in the token claims.
            var (contactEntities, paginationMetaData) = await _contactsRepository.GetContactsAsync(name, searchQuery, pageNumber, pageSize);

            return Ok(_mapper.Map<IEnumerable<ContactDTO>>(contactEntities));
        }

        // User-specific actions for managing contacts can be placed here
        // For example, methods to add, update, or delete contacts specific to the authenticated user can be implemented here.

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDTO updatedContactDto)
        {
            if (updatedContactDto == null)
            {
                return BadRequest("Contact data is null.");
            }

            var existingContact = await _contactsRepository.GetContactsAsync(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedContactDto, existingContact);
            await _contactsRepository.SaveChangesAsync();

            return Ok(_mapper.Map<ContactDTO>(existingContact));
        }
    }
}
