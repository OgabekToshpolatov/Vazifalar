using System.Security.Claims;
using mvc.Models;
using mvc.ViewModel;

namespace mvc.Services;

public interface IOrganizationService
{
    Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationModel createOrganizationModel);
    Task<OrganizationModel> GetOrganizationByIdAsync(Guid organizationId);
}