using mvc.Dtos;
using mvc.Models;

namespace mvc.Services;

public interface IContactService
{
    Task<List<ContactViewModel>> GetContacts();
    Task<ContactViewModel> CreateContact(CreateContactDto dto);
}