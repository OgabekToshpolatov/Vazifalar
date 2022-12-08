using System.Security.Claims;
using mvc.Models;

namespace mvc.Services;

public interface IOrganizationService
{
    Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationModel createOrganizationModel);
}