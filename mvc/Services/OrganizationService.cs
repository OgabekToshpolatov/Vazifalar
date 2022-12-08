using System.Security.Claims;
using Mapster;
using mvc.Data;
using mvc.Entities;
using mvc.Models;

namespace mvc.Services;

public class OrganizationService : IOrganizationService
{
    private readonly AppDbContext _context;

    public OrganizationService(AppDbContext context)
    {
        _context = context ;
    }
    public async Task AddOrganization(ClaimsPrincipal claims, CreateOrganizationModel createOrganizationModel)
    {
        var organization = createOrganizationModel.Adapt<Organization>();
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        organization.Users = new List<OrganizationUser>()
        {
             new OrganizationUser()
             {
                Role = ERole.Owner,
                UserId = userId
             }
        };

        await _context.Organizations.AddAsync(organization);
        await _context.SaveChangesAsync();
    }
    
}