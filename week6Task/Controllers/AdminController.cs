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
   [Authorize(Policy = "AdminPolicy")]
    [Route("api/admin/contacts")]
    public class AdminController : ControllerBase
    {
        private readonly IcontactsRepository _contactsRepository;

        private readonly IMapper _mapper;

        const int maxContactsPageSize = 20;

        public AdminController(IcontactsRepository contactsRepository, IMapper mapper)
        {
            _contactsRepository = contactsRepository ?? throw new Exception(nameof(contactsRepository));
            _mapper = mapper ?? throw new Exception(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllUsers(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxContactsPageSize)
            {
                pageSize = maxContactsPageSize;
            }
            var (contactEntities, paginationMetaData) = await _contactsRepository.GetContactsAsync(name, searchQuery, pageNumber, pageSize);

            return Ok(_mapper.Map<IEnumerable<ContactDTO>>(contactEntities));
        }

        [HttpGet("{id}", Name = "GetContact")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contactToReturn = await _contactsRepository.GetContactsAsync(id);
            if (contactToReturn == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContactDTO>(contactToReturn));
        }

        [HttpPost]
        public async Task<ActionResult<ContactDTO>> CreateContact([FromBody] ContactDTO contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest("Contact data is null.");
            }

            var finalContact = _mapper.Map<Contacts>(contactDto);
          

            _contactsRepository.AddContactsAsync(finalContact);
            await _contactsRepository.SaveChangesAsync();

            return CreatedAtRoute("GetContact", new { id = finalContact.ContactsId }, _mapper.Map<ContactDTO>(finalContact));
        }

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

        [HttpPatch("{id}/photo")]
        public async Task<IActionResult> UpdateContactPhoto(int id, [FromBody] PhotoUpdateDTO contactPhotoDto)
        {
            if (contactPhotoDto == null)
            {
                return BadRequest("Contact photo data is null.");
            }

            var existingContact = await _contactsRepository.GetContactsAsync(id);
            if (existingContact == null)
            {
                return NotFound();
            }

            existingContact.PhotoUrl = contactPhotoDto.PhotoUrl;
            await _contactsRepository.SaveChangesAsync();

            return Ok(_mapper.Map<ContactDTO>(existingContact));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contactToDelete = await _contactsRepository.GetContactsAsync(id);
            if (contactToDelete == null)
            {
                return NotFound();
            }

            _contactsRepository.DeleteContact(contactToDelete);
            await _contactsRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}

