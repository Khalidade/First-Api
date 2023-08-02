//using Microsoft.AspNetCore.Mvc;
//using week6Task.Models;
//using System.Linq;
//using week6Task.Services;
//using AutoMapper;
//using week6Task.Entities;
//using System.Text.Json;
//using Microsoft.AspNetCore.Authorization;

//namespace week6Task.Controllers
//{
//    [ApiController]
//    [Authorize]
//    [Route("api/contacts")]
//    public class ContactBookController : ControllerBase
//    {
//        private readonly IcontactsRepository _contactsRepository;

//        private readonly IMapper _mapper;

//        const int maxContactsPageSize = 20;

//        public ContactBookController(IcontactsRepository contactsRepository, IMapper mapper)
//        {
//            _contactsRepository = contactsRepository ?? throw new Exception(nameof(contactsRepository));
//            _mapper = mapper ?? throw new Exception(nameof(mapper));
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllUsers(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
//        {
//            if(pageSize >  maxContactsPageSize)
//            {
//                pageSize = maxContactsPageSize;
//            }
//            var (contactEntities, paginationMetaData) = await _contactsRepository.GetContactsAsync(name, searchQuery, pageNumber, pageSize);

//            return Ok(_mapper.Map<IEnumerable<ContactDTO>>(contactEntities));
//        }

//        [HttpGet("{id}", Name = "GetContact")]
//        public async Task<IActionResult> GetId(int ContactId)
//        {
//            var contactToReturn = await _contactsRepository.GetContactsAsync(ContactId);
//            if (contactToReturn == null)
//            {
//                return NotFound();
//            }

//            return Ok(_mapper.Map<ContactDTO>(contactToReturn));
//        }
        
//        [HttpPost]
//        public async Task<ActionResult<ContactDTO>> CreateContact([FromBody] ContactDTO contactDto)
//        {
//            if (contactDto == null)
//            {
//                return BadRequest("Contact data is null.");
//            }

//            // You might want to check if a contact with the same ID already exists and handle that scenario accordingly.
//            // For example, if you use a unique ID for each contact, you can check if a contact with the same ID already exists.

//            // Map the ContactDTO to the Contacts entity
//            var finalContact = _mapper.Map<Contacts>(contactDto);

//            // Add the contact to the repository
//            _contactsRepository.AddContactsAsync(finalContact);
//            await _contactsRepository.SaveChangesAsync();

//            // Return the created contact with a "201 Created" status and the "Location" header set to the URL of the new contact
//            return CreatedAtRoute("GetContact", new { id = finalContact.ContactsId }, _mapper.Map<ContactDTO>(finalContact));
//        }




//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDTO updatedContactDto)
//        {
//            if (updatedContactDto == null)
//            {
//                return BadRequest("Contact data is null.");
//            }

//            // Check if the contact with the specified ID exists
//            var existingContact = await _contactsRepository.GetContactsAsync(id);
//            if (existingContact == null)
//            {
//                return NotFound();
//            }

//            // Update the existing contact with the new data
//            _mapper.Map(updatedContactDto, existingContact);
//            await _contactsRepository.SaveChangesAsync();

//            // Return the updated contact
//            return Ok(_mapper.Map<ContactDTO>(existingContact));
//        }


//        [HttpPatch("{id}/photo")]
//        public async Task<IActionResult> UpdateContactPhoto(int id, [FromBody] PhotoUpdateDTO contactPhotoDto)
//        {
//            if (contactPhotoDto == null)
//            {
//                return BadRequest("Contact photo data is null.");
//            }

//            // Check if the contact with the specified ID exists
//            var existingContact = await _contactsRepository.GetContactsAsync(id);
//            if (existingContact == null)
//            {
//                return NotFound();
//            }

//            // Update the contact's photo URL
//            existingContact.PhotoUrl = contactPhotoDto.PhotoUrl;
//            await _contactsRepository.SaveChangesAsync();

//            // Return the updated contact with photo URL
//            return Ok(_mapper.Map<ContactDTO>(existingContact));
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteContact(int id)
//        {
//            // Check if the contact with the specified ID exists
//            var contactToDelete = await _contactsRepository.GetContactsAsync(id);
//            if (contactToDelete == null)
//            {
//                return NotFound();
//            }

//            // Delete the contact from the repository
//            _contactsRepository.DeleteContact(contactToDelete);
//            await _contactsRepository.SaveChangesAsync();

//            return NoContent();
//        }




//    }
//}
